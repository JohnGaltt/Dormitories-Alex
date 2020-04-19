﻿using Newtonsoft.Json;

namespace Dormitories.Core.BusinessLogic.ViewModels
{
    public class CreateUserViewModel
    {
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

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
