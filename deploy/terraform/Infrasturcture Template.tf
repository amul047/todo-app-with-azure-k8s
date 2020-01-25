provider "azurerm" {
}
resource "azurerm_resource_group" "tdrg" {
        name = "todoresourcegroup"
        location = "australiaeast"
}

resource "azurerm_kubernetes_cluster" "tdkc" {
  name                = "todokubernetescluster"
  location            = azurerm_resource_group.tdrg.location
  resource_group_name = azurerm_resource_group.tdrg.name
  dns_prefix          = "todokubernetescluster"

  addon_profile {
    kube_dashboard {
      enabled = true
    }
  }
  
  service_principal {
    client_id     = "a34b48e9-c29b-4a1f-8b56-20b92deb95ff"
    client_secret = "8c94a1df-295f-4d7c-85e2-a53ea30ac032"
  }

  tags = {
    Environment = "Production"
  }
  
  default_node_pool {
    vm_size    = "Standard_D2_v2"
    name       = "tduaprofile"
	node_count = 1
  }
}

output "client_certificate" {
  value = azurerm_kubernetes_cluster.tdkc.kube_config.0.client_certificate
}

output "kube_config" {
  value = azurerm_kubernetes_cluster.tdkc.kube_config_raw
}

provider "kubernetes" {
  host                   = azurerm_kubernetes_cluster.tdkc.kube_config.0.host
  client_certificate     = base64decode(azurerm_kubernetes_cluster.tdkc.kube_config.0.client_certificate)
  client_key             = base64decode(azurerm_kubernetes_cluster.tdkc.kube_config.0.client_key)
  cluster_ca_certificate = base64decode(azurerm_kubernetes_cluster.tdkc.kube_config.0.cluster_ca_certificate)
}

resource "kubernetes_pod" "tduap" {
  metadata {
    name = "todoupdatesapipod"
    labels = {
      App = "toDoUpdatesApi"
    }
  }

  spec {
    container {
      image = "amul047/updatesapi"
      name  = "todoupdatesapicontainer"
	  
      port {
        container_port = 80
      }
    }
  }
}

resource "kubernetes_service" "tduas" {
  metadata {
    name = "todoupdatesapiservice"
  }
  spec {
    selector = {
      App = kubernetes_pod.tduap.metadata[0].labels.App
    }
    port {
      port        = 80
      target_port = 80
    }

    type = "LoadBalancer"
  }
}