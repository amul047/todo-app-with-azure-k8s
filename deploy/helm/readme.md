Remember to set the current context of your kubernetes client to the cluster created in terraform.

Then run the following command to do a deployment.

```
helm install ./todo-chart --generate-name -v 20
```