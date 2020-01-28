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
