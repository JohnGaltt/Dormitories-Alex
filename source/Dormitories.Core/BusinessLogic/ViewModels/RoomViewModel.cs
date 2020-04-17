using Newtonsoft.Json;

namespace Dormitories.Core.BusinessLogic.ViewModels
{
    public class RoomViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("dormitoryId")]
        public int DormitoryId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("floor")]
        public string Floor { get; set; }

        [JsonProperty("dormitoryName")]
        public string DormitoryName { get; set; }

        [JsonProperty("dormitoryAddress")]
        public string DormitoryAddress { get; set; }
    }
}
