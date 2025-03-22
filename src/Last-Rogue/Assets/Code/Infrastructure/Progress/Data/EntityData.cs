using System.Collections.Generic;
using Newtonsoft.Json;

namespace Code.Infrastructure.Progress.Data
{
    public class EntityData
    {
        [JsonProperty("es")] public List<EntitySnapshot> MetaEntitySnapshots;
    }
}