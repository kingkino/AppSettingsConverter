using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AppSettingsConverter.Json
{
    public class JsonFieldsCollector
    {
        private readonly Dictionary<string, JValue> _fields;

        public JsonFieldsCollector(JToken token)
        {
            _fields = new Dictionary<string, JValue>();
            CollectFields(token);
        }

        private void CollectFields(JToken jToken)
        {
            switch (jToken.Type)
            {
                case JTokenType.Object:
                    foreach (var child in jToken.Children<JProperty>())
                        CollectFields(child);
                    break;
                case JTokenType.Array:
                    foreach (var child in jToken.Children())
                        CollectFields(child);
                    break;
                case JTokenType.Property:
                    CollectFields(((JProperty)jToken).Value);
                    break;
                default:
                    _fields.Add(jToken.Path, (JValue)jToken);
                    break;
            }
        }

        public IEnumerable<KeyValuePair<string, JValue>> GetAllFields() => _fields;
    }
}
