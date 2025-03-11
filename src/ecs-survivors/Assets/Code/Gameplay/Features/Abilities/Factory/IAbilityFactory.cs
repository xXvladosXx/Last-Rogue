namespace Code.Gameplay.Features.Abilities.Factory
{
    public interface IAbilityFactory
    {
        GameEntity CreateVegetableBoltAbility(int level);
        GameEntity CreateOrbitalMushroomAbility(int level);
        GameEntity CreateGarlicAuraAbility(int level);
    }
}