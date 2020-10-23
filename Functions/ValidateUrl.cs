
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using CaliSharp.Demo.Spec;

namespace CaliSharp.Demo.Functions
{
    public class ValidateUrl
    {
        private readonly HttpClient _client;
        private readonly ITeamsNotifier _teams;

        public ValidateUrl(IHttpClientFactory clientFactory, ITeamsNotifier teams)
        {
            _client = clientFactory.CreateClient();
            _teams = teams;
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
