# To do application
Create, update, read and delete to do items

## URL

## Solution summary


## Solution tasks
* Create a AKS cluster using Terraform :heavy_check_mark:
* Create and deploy the following components into the AKS cluster using Helm :heavy_check_mark:
  * SQL database to store the change events :heavy_exclamation_mark: as a managed service by Azure, not via Helm
  * .NET core API to capture updates (events) for read to do items :heavy_check_mark:
  * .NET core service worker to action these changes :heavy_check_mark:
  * .NET core API to read the to do items (projections)
  * Front end application in vue.js to capture the to do items
* Write the solution summary and update URL
* Give permissions to GitHub repository
* Give permissions to Azure resource groups
* Email back with link to GitHub

## Technical debt:
* Deploying SQL instance as a service in AKS cluster
* Adding authentication and authorisation
* Moving database credentials to secrets
* Use messaging instead of polling to decrease infrastructure costs




