namespace Code.Gameplay.Features.Effects.Factory
{
    public interface IEffectFactory
    {
        GameEntity CreateEffect(EffectSetup effectSetup, int producerId, int targetId);
    }
}