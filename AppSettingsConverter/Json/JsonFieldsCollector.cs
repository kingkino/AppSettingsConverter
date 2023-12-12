using AppSettingsConverter.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using static AppSettingsConverter.Json.JsonFieldsCollector;

namespace AppSettingsConverter.Json
{
    public class JsonFieldsCollector
    {
        private readonly List<OutputItem> _outputItems;

        public JsonFieldsCollector(JToken token)
        {
            _outputItems = new List<OutputItem>();
            CollectFields(token);
        }

        private void CollectFields(JToken jToken, string parentKey = "")
        {
            switch (jToken.Type)
            {
                case JTokenType.Object:
                    foreach (var child in jToken.Children<JProperty>())
                    {
                        var childKey = child.Name;
                        CollectFields(child.Value, $"{parentKey}{(string.IsNullOrEmpty(parentKey) ? "" : ":")}{childKey}");
                    }
                    break;
                case JTokenType.Array:
                    for (int i = 0; i < jToken.Count(); i++)
                    {
                        CollectFields(jToken[i], $"{parentKey}{(string.IsNullOrEmpty(parentKey) ? "" : ":")}{i}");
                    }
                    break;
                default:
                    _outputItems.Add(new OutputItem
                    {
                        Name = $"{parentKey}",
                        Value = jToken.ToString(),
                        SlotSetting = false
                    });
                    break;
            }
        }

        public IEnumerable<OutputItem> GetAllFields() => _outputItems;
    }
}
