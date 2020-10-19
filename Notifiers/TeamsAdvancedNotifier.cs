
namespace CaliSharp.Demo.Notifiers
{
    public class TeamsAdvancedNotifier : TeamsNotifier
    {
        private readonly string _callbackUrl;
        public TeamsAdvancedNotifier(string hookUrl, string callbackUrl)
            : base(hookUrl)
        {
            _callbackUrl = callbackUrl;
        }

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
                    }},
                    {{
                        '@type': 'ActionCard',
                        'name': 'Actualizar URL',
                        'inputs': [{{
                            '@type': 'TextInput',
                            'id': 'comment',
                            'isMultiline': false,
                            'title': 'Indique la nueva URL'
                        }}],
                        'actions': [{{
                            '@type': 'HttpPOST',
                            'name': 'Update Url',
                            'target': '{_callbackUrl}'
                        }}]
                    }}
                ]
            }}";

            return hookMessage;
        }
    }
}