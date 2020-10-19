using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CaliSharp.Demo.Notifiers
{
    public class TeamsNotifier
    {
        private readonly string _hookUrl;

        public TeamsNotifier(string hookUrl)
        {
            _hookUrl = hookUrl;
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