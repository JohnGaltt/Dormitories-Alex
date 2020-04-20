using Newtonsoft.Json;
using System;

namespace Dormitories.Core.BusinessLogic.ViewModels
{
    public class PartialUpdateUserViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("expireAt")]
        public DateTime? ExpireAt { get; set; }
    }
}
