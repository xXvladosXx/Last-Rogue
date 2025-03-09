namespace Code.Gameplay.Features.Statuses.Systems
{
    public interface IStatusApplier
    {
        GameEntity ApplyStatus(StatusSetup setup, int producerId, int targetId);
    }
}