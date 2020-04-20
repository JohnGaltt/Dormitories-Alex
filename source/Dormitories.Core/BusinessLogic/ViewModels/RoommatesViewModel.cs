using Newtonsoft.Json;

namespace Dormitories.Core.BusinessLogic.ViewModels
{
    public class RoommatesViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("roomName")]
        public string RoomName { get; set; }

        [JsonProperty("roomFloor")]
        public string RoomFloor { get; set; }

        [JsonProperty("dormitoryAddress")]
        public string DormitoryAddress { get; set; }

        [JsonProperty("dormitoryName")]
        public string DormitoryName { get; set; }
    }
}
