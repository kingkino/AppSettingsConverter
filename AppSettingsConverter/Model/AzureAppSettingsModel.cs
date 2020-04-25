using Newtonsoft.Json;

namespace AppSettingsConverter.Model
{
    public class AzureAppSettings
    {
        public AzureAppSettingsModel[] root { get; set; }
    }

    public class AzureAppSettingsModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("slotSetting")]
        public string SlotSetting { get; set; }
    }
}
