# To do application
Create, update, read and delete to do items

## URL

## Solution summary
When the application creates, updates or deletes to do items, it eventually updates the to do items that are read.

The following sequence diagram shows how the data flows through the various components to achieve eventual consistency.
![Sequence diagram of my proposed solution](/images/sequence.png)

## Solution tasks
* Create an AKS cluster using Terraform :heavy_check_mark:
* Create and deploy the following components into the AKS cluster using Helm :heavy_check_mark:
  * SQL database to store the change events :heavy_exclamation_mark: as a managed service by Azure, not via Helm
  * .NET core API to capture updates (events) for read to do items :heavy_check_mark:
  * .NET core service worker to action these changes :heavy_check_mark:
  * .NET core API to read the to do items (projections) :heavy_check_mark: - http://todoitemsapi.australiaeast.azurecontainer.io/
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
* Use signalr to notify front end of data update
* Update helm deploy to deal with dependent deployments
  * SQL database server is currently managed
  * API to read items is currently on managed Azure Container Service





