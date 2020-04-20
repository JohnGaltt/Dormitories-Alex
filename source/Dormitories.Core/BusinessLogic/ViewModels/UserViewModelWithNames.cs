using Newtonsoft.Json;
using System;

namespace Dormitories.Core.BusinessLogic.ViewModels
{
    public class UserViewModelWithNames
    {
        [JsonProperty("id")]
        public int UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("roomName")]
        public string RoomName { get; set; }

        [JsonProperty("roomFloor")]
        public string RoomFloor { get; set; }

        [JsonProperty("dormitoryAddress")]
        public string DormitoryAddress { get; set; }

        [JsonProperty("dormitoryName")]
        public string DormitoryName { get; set; }

        [JsonProperty("expireAt")]
        public DateTime? ExpireAt { get; set; }
    }
}
