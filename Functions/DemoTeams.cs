using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace CaliSharp.Demo.Functions
{
    public static class DemoTeams
    {
        [FunctionName("DemoTeams")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] DemoTeamsRequest form,
            [Queue("demoteams"), StorageAccount("AzureWebJobsStorage")] ICollector<string> queue,
            ILogger log)
        {
            log.LogInformation("Running DemoTeams function");

            foreach (var url in form.URLs)
            {
                queue.Add(url);
            }

            var response = new
            {
                Msg = "CaliSharp de Octubre",
                Urls = form.URLs
            };

            return new OkObjectResult(response);
        }
    }

    public class DemoTeamsRequest
    {
        public IEnumerable<string> URLs { get; set; }
    }
}
