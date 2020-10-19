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
            var hookUrl = Environment.GetEnvironmentVariable("HookUrl", EnvironmentVariableTarget.Process);
            var callbackUrl = Environment.GetEnvironmentVariable("CallbackUrl", EnvironmentVariableTarget.Process);

            _client = new HttpClient();

            // _teams = new TeamsNotifier(hookUrl);
            // _teams = new TeamsAdvancedNotifier(hookUrl, callbackUrl);
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
            catch
            {
                _teams.NotifyBrokenUrl(url);
            }
        }
    }
}
