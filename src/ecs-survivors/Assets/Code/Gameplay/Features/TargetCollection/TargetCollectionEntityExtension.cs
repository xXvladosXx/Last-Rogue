namespace Code.Gameplay.Features.TargetCollection
{
    public static class TargetCollectionEntityExtension
    {
        public static GameEntity RemoveTargetCollectionComponents(this GameEntity entity)
        {
            if (entity.hasTargetsBuffer)
            {
                entity.RemoveTargetsBuffer();
            }

            if (entity.hasCollectTargetsInterval)
            {
                entity.RemoveCollectTargetsInterval();
            }

            if (entity.hasCollectTargetsTimer)
            {
                entity.RemoveCollectTargetsTimer();
            }

            entity.isReadyToCollectTargets = true;

            return entity;
        }
    }
}