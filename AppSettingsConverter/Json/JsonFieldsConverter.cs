using AppSettingsConverter.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AppSettingsConverter.Json
{
    public class JsonFieldsConverter
    {
        public static JToken ConvertToJToken(IEnumerable<OutputItem> outputItems)
        {
            var root = new JObject();
            foreach (var item in outputItems)
            {
                var pathSegments = item.Name.Split(':');
                var currentToken = root;

                for (int i = 0; i < pathSegments.Length - 1; i++)
                {
                    var segment = pathSegments[i];
                    if (!currentToken.TryGetValue(segment, out var existingToken) || existingToken.Type != JTokenType.Object)
                    {
                        existingToken = new JObject();
                        currentToken[segment] = existingToken;
                    }

                    currentToken = (JObject)existingToken;
                }

                currentToken[pathSegments[pathSegments.Length - 1]] = new JValue(item.Value);
            }

            return root;
        }
    }
}
