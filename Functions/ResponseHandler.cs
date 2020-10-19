using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace CaliSharp.Demo.Functions
{
    public static class ResponseHandler
    {
        [FunctionName("ResponseHandler")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "url")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Running ResponseHandler function");

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            log.LogWarning(content);

            return new OkResult();
        }
    }
}
