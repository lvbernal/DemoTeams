
namespace CaliSharp.Demo.Notifiers
{
    public class TeamsAdvancedNotifier : TeamsNotifier
    {
        public TeamsAdvancedNotifier(string hookUrl) : base(hookUrl) { }

        protected override string BuildHookMessage(string url)
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
    }
}