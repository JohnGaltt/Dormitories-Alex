using Newtonsoft.Json;

namespace Dormitories.Core.DataAccess.ViewModels
{
    public class AccountViewModel
    {
        [JsonProperty("id")]
        public int UserId { get; set; }

        [JsonProperty("name")]
        public string UserName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("roles")]
        public string Roles { get; set; }

        public string EmailConfirmed { get; set; }

        [JsonProperty("roomName")]
        public string RoomName { get; set; }
        
        [JsonProperty("roomFloor")]
        public string RoomFloor { get; set; }

        [JsonProperty("dormitoryAddress")]
        public string DormitoryAddress { get; set; }

        [JsonProperty("dormitoryName")]
        public string DormitoryName { get; set; }

        [JsonProperty("dormitoryId")]
        public int DormitoryId { get; set; }

        [JsonProperty("roomId")]
        public int? RoomId { get; set; }
    }
}
