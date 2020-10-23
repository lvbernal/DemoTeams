
using Microsoft.Extensions.Options;

namespace CaliSharp.Demo.Notifiers
{
    public class AdvancedTeamsNotifier : TeamsNotifier
    {
        private readonly string _callbackUrl;

        public AdvancedTeamsNotifier(IOptions<Options> options)
            : base(options)
        {
            _callbackUrl = options.Value.CallbackUrl;
        }

        protected override string BuildHookMessage(string url)
        {
            var bodyFormat = "{ \"newUrl\": \"{{newUrl.value}}\" }";

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
                            'id': 'newUrl',
                            'isMultiline': false,
                            'title': 'Indique la nueva URL'
                        }}],
                        'actions': [{{
                            '@type': 'HttpPOST',
                            'name': 'Actualizar URL',
                            'body': '{bodyFormat}',
                            'target': '{_callbackUrl}'
                        }}]
                    }}
                ]
            }}";

            return hookMessage;
        }
    }
}