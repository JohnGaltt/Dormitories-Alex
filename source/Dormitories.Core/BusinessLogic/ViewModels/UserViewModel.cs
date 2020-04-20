using Newtonsoft.Json;
using System;

namespace Dormitories.Core.BusinessLogic.ViewModels
{
    public class UserViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("dormitoryId")]
        public int DormitoryId { get; set; }

        [JsonProperty("roomId")]
        public int RoomId { get; set; }

        [JsonProperty("roleId")]
        public int RoleId { get; set; }

        [JsonProperty("expireAt")]
        public DateTime? ExpireAt { get; set; }
    }
}
