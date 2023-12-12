using AppSettingsConverter.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace AppSettingsConverter.Json
{
    public class JsonFieldsConverter
    {
        public static JArray ConvertToJArray(IEnumerable<OutputItem> outputItems)
        {
            var jsonArray = new JArray();
            foreach (var item in outputItems)
            {
                var pathSegments = item.Name.Split(':');
                var currentObject = new JObject();

                currentObject.Add(pathSegments[pathSegments.Length - 1], new JValue(item.Value));

                for (int i = pathSegments.Length - 2; i >= 0; i--)
                {
                    var newObj = new JObject();
                    newObj.Add(pathSegments[i], currentObject);
                    currentObject = newObj;
                }

                jsonArray.Add(currentObject);
            }

            return jsonArray;
        }
    }
}
