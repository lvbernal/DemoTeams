# CaliSharp de Octubre 2020

Demo de integraciones con Teams.

[Sitio del evento](https://www.meetup.com/CaliSharpCO/events/274024056/)

## Requisitos

1. Crear una cuenta de almacenamiento (_Storage Account_) de Azure.
2. Agregar una cola (_queue_) llamada `demoteams`.
3. Configurar las variables de entorno en el archivo `local.settings.json`. Crearlo si no existe.
    * AzureWebJobsStorage: Cadena de conexión de la cuenta de almacenamiento.
    * HookUrl: URL del _Incoming Webhook_ de Teams.

```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet",
        "HookUrl": ""
    }
}
```

## Enlaces de interés

General:

* [Comunidad CaliSharp](https://www.meetup.com/CaliSharpCO)
* [Evento de octubre 2020](https://www.meetup.com/CaliSharpCO/events/274024056/)

Documentación:

* [Create a storage account](https://docs.microsoft.com/en-us/azure/storage/common/storage-account-create)
* [Add an incoming webhook to a Teams channel](https://docs.microsoft.com/en-us/microsoftteams/platform/webhooks-and-connectors/how-to/add-incoming-webhook#add-an-incoming-webhook-to-a-teams-channel)
* [Sending messages to connectors and webhooks](https://docs.microsoft.com/en-us/microsoftteams/platform/webhooks-and-connectors/how-to/connectors-using)
* [Office 365 connector card](https://docs.microsoft.com/en-us/microsoftteams/platform/task-modules-and-cards/cards/cards-reference#office-365-connector-card)
* [Work with Azure Functions Core Tools](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local)
* [Message card playground](https://messagecardplayground.azurewebsites.net/)