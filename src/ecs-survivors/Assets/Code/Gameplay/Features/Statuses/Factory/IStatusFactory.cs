namespace Code.Gameplay.Features.Statuses.Factory
{
    public interface IStatusFactory
    {
        GameEntity CreateStatus(StatusSetup statusSetup, int producerId, int targetId);
    }
}