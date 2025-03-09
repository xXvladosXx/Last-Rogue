using System;
using System.Collections.Generic;
using System.Linq;

namespace Code.Gameplay.Features.CharacterStats
{
    public enum Stats
    {
        Unknown = 0,
        MaxHealth = 1,
        Damage = 2,
        Speed = 3,
    }

    public static class InitStats
    {
        public static Dictionary<Stats, float> EmptyStatDictionary() =>
            Enum.GetValues(typeof(Stats))
                .Cast<Stats>()
                .Except(new[] {Stats.Unknown})
                .ToDictionary(x => x, _ => 0f);
    }
}