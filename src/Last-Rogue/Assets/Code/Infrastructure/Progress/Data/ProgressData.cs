using System;
using Newtonsoft.Json;

namespace Code.Infrastructure.Progress.Data
{
    public class ProgressData
    {
        [JsonProperty("e")] public EntityData EntityData = new EntityData();
        [JsonProperty("at")] public DateTime LastSimulationTickTime;
    }
}