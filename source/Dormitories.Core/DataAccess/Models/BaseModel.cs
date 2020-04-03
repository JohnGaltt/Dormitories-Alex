using Newtonsoft.Json;

namespace Dormitories.Core.DataAccess
{
    public class BaseModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
