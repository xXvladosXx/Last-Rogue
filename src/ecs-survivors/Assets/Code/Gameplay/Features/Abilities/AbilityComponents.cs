using Entitas;

namespace Code.Gameplay.Features.Abilities
{
    public class AbilityComponents
    {
        [Game] public class AbilityIdComponent : IComponent { public AbilityId Value; }
        [Game] public class VegetableBoltAbility : IComponent { }
    }
}