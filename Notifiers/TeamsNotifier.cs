using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CaliSharp.Demo.Spec;
using Microsoft.Extensions.Options;

namespace CaliSharp.Demo.Notifiers
{
    public class TeamsNotifier : ITeamsNotifier
    {
        private readonly string _hookUrl;

        public TeamsNotifier(IOptions<Options> options)
        {
            _hookUrl = options.Value.HookUrl;
        }

        public void NotifyBrokenUrl(string url)
        {
            var message = BuildHookMessage(url);
            _ = SendMessage(message);
        }

        protected virtual string BuildHookMessage(string url)
        {
            var hookMessage = $@"
            {{
                '@context': 'https://schema.org/extensions',
                '@type': 'MessageCard',
                'themeColor': '0072C6',
                'title': 'Demo CaliSharp',
                'text': 'El enlace _{url}_ está roto',
                'potentialAction': [
                    {{
                        '@type': 'OpenUri',
                        'name': 'Visitar enlace',
                        'targets': [
                            {{
                                'os': 'default',
                                'uri': '{url}'
                            }}
                        ]
                    }}
                ]
            }}";

            return hookMessage;
        }

        private async Task SendMessage(string message)
        {
            using var client = new HttpClient();
            var content = new StringContent(message, Encoding.UTF8, "application/json");
            await client.PostAsync(_hookUrl, content);
        }
    }
}