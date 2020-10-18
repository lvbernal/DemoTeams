using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using CaliSharp.Demo.Notifiers;

namespace CaliSharp.Demo.Functions
{
    public class ValidateUrl
    {
        private readonly HttpClient _client;
        private readonly TeamsNotifier _teams;

        public ValidateUrl()
        {
            _client = new HttpClient();

            var hookUrl = Environment.GetEnvironmentVariable("HookUrl", EnvironmentVariableTarget.Process);
            _teams = new TeamsNotifier(hookUrl);
        }

        [FunctionName("ValidateUrl")]
        public async Task Run(
            [QueueTrigger("demoteams", Connection = "AzureWebJobsStorage")] string url,
            ILogger log)
        {
            try
            {
                log.LogInformation($"Running ValidateUrl function for url {url}");

                var response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                _teams.NotifyBrokenUrl(url);
            }
        }
    }
}
