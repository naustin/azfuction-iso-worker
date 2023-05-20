using Pulumi;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Apps.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using System.Collections.Generic;
using Pulumi;
using AzureNative = Pulumi.AzureNative;

return await Deployment.RunAsync(() =>
{
    var resourceGroup = new AzureNative.Resources.ResourceGroup("resourceGroup", new()
    {
        Location = "eastus",
        ResourceGroupName = "k6-API",
    });

var functionStorage = new AzureNative.Storage.StorageAccount("functionStorage", new()
    {
        AccountName = "functionStorage",
        Kind =  "StorageV2",
        Location = "eastus",
        AllowBlobPublicAccess = false,
        ResourceGroupName = resourceGroup.Name,
        Sku = new AzureNative.Storage.Inputs.SkuArgs
        {
            Name = "Standard_LRS",
        },
    });


/*
    const storageAccount = new storage.StorageAccount("sa", {
    resourceGroupName: resourceGroup.name,
    sku: {
        name: storage.SkuName.Standard_LRS,
    },
    kind: storage.Kind.StorageV2,
});

    const codeContainer = new storage.BlobContainer("zips", {
    resourceGroupName: resourceGroup.name,
    accountName: storageAccount.name,
});


// Upload Azure Function's code as a zip archive to the storage account.
const codeBlob = new storage.Blob("zip", {
    resourceGroupName: resourceGroup.name,
    accountName: storageAccount.name,
    containerName: codeContainer.name,
    source: new pulumi.asset.FileArchive("./javascript"),
});

// Define a Consumption Plan for the Function App.
// You can change the SKU to Premium or App Service Plan if needed.
const plan = new web.AppServicePlan("plan", {
    resourceGroupName: resourceGroup.name,
    sku: {
        name: "Y1",
        tier: "Dynamic",
    },
});

// Build the connection string and zip archive's SAS URL. They will go to Function App's settings.
const storageConnectionString = getConnectionString(resourceGroup.name, storageAccount.name);
const codeBlobUrl = signedBlobReadUrl(codeBlob, codeContainer, storageAccount, resourceGroup);

const app = new web.WebApp("fa", {
    resourceGroupName: resourceGroup.name,
    serverFarmId: plan.id,
    kind: "functionapp",
    siteConfig: {
        appSettings: [
            { name: "AzureWebJobsStorage", value: storageConnectionString },
            { name: "FUNCTIONS_EXTENSION_VERSION", value: "~3" },
            { name: "FUNCTIONS_WORKER_RUNTIME", value: "node" },
            { name: "WEBSITE_NODE_DEFAULT_VERSION", value: "~14" },
            { name: "WEBSITE_RUN_FROM_PACKAGE", value: codeBlobUrl },
        ],
        http20Enabled: true,
        nodeVersion: "~14",
    },
});

export const endpoint = pulumi.interpolate`https://${app.defaultHostName}/api/HelloNode?name=Pulumi`;
*/

});
