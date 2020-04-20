using Dormitories.Core.DataAccess.Models;
using Newtonsoft.Json;

namespace Dormitories.Core.BusinessLogic.ViewModels
{
    public class RequestViewModel
    {
        [JsonProperty("requestType")]
        public RequestTypes RequestType { get; set; }

        [JsonProperty("itemId")]
        public int? ItemId { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("userEmail")]
        public string UserEmail { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
