# CaliSharp de Octubre 2020

Demo de integraciones con Teams.

## Requisitos

1. Crear una cuenta de almacenamiento (_Storage Account_) de Azure.
2. Agregar una cola (_queue_) llamada `demoteams`.
3. Configurar las variables de entorno en el archivo `local.settings.json`.
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