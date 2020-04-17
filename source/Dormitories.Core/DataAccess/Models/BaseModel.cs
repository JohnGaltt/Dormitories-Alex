using AutoMapper;
using Newtonsoft.Json;

namespace Dormitories.Core.DataAccess
{
    public class BaseModel
    {
        [IgnoreMap]
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
