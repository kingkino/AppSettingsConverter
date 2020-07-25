using Newtonsoft.Json;

namespace AppSettingsConverter.Model
{
    public class AzureAppSettings
    {
        public AzureAppSettingsModel[] Root { get; set; }
    }

    public class AzureAppSettingsModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("slotSetting")]
        public bool SlotSetting { get; set; }
    }
}
