using Newtonsoft.Json;

namespace Dormitories.Api.ViewModels
{
    public class DormitoryViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
