provider "azurerm" {
}
resource "azurerm_resource_group" "rg" {
        name = "todoResourceGroup"
        location = "australiaeast"
}

resource "azurerm_kubernetes_cluster" "example" {
  name                = "todoKubernetesCluster"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  dns_prefix          = "todoKubernetesCluster"

  default_node_pool {
    name       = "default"
    node_count = 1
    vm_size    = "Standard_D2_v2"
  }
  
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
}

output "client_certificate" {
  value = azurerm_kubernetes_cluster.example.kube_config.0.client_certificate
}

output "kube_config" {
  value = azurerm_kubernetes_cluster.example.kube_config_raw
}