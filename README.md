# To do application
Objective: Create, update, read and delete to do items

Plan:
- Create a AKS cluster using Terraform :heavy_check_mark:
- Deploy the components into the AKS cluster using Helm :heavy_check_mark:
- SQL database to store the change events :heavy_exclamation_mark: as a managed service by Azure, not via Helm
- .NET core API to capture updates (events) for read to do items :heavy_check_mark:
- .NET core service worker to action these changes
- .NET core API to read the to do items (projections)
- Front end application in vue.js to capture the to do items

