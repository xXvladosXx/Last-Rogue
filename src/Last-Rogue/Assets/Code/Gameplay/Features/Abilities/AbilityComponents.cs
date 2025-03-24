using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Gameplay.Features.Abilities
{
    public class AbilityComponents
    {
        [Game] public class AbilityIdComponent : IComponent { public AbilityId Value; }
        [Game] public class ParentAbility : IComponent { [EntityIndex] public AbilityId Value; }
        [Game] public class VegetableBoltAbility : IComponent { }
        [Game] public class OrbitingMushroomAbility : IComponent { }
        [Game] public class GarlicAuraAbility : IComponent { }
        [Game] public class UpgradeRequest : IComponent { }
        [Game] public class RecreatedOnUpgrade : IComponent { }
        [Game] public class ShovelRadialStrikeAbility : IComponent { }
        [Game] public class ScatteringFireballAbility : IComponent { }
        [Game] public class ScheduledToProcessByArmaments : IComponent { public List<int> Value; }
        [Game] public class ProcessedByArmaments: IComponent { public List<int> Value; }
    }
}