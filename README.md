# To do application
Create, update, read and delete to do items

## Application URL

## Solution summary
When a user creates, updates or deletes to do items through the application, it propagates through the various components  to the to do items database. The application constantly fetches (could be pushed) the to do items that have been propagated. User, therefore, can see the to do items updating as he/she interacts with the application.

![Sequence diagram of my proposed solution](/images/sequence.png)

## Solution tasks
* Create an AKS cluster using Terraform :heavy_check_mark: - todokubernetescluster-8319726c.hcp.australiaeast.azmk8s.io
* Create and deploy the following components into the AKS cluster using Helm :heavy_check_mark:
  * SQL database to store the change events :heavy_exclamation_mark: - aamirtodo.database.windows.net
  * .NET core API to capture updates (events) for read to do items :heavy_check_mark:
  * .NET core service worker to action these changes :heavy_check_mark:
  * .NET core API to read the to do items (projections) :heavy_exclamation_mark: - http://todoitemsapi.australiaeast.azurecontainer.io/
  * Front end application in vue.js to capture the to do items
* Write the solution summary :heavy_check_mark:
* Give collaborator permissions to GitHub repository :heavy_check_mark:
* Give read permissions to Azure resource groups :heavy_check_mark:
* Update application URL
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
