using System.Collections.Generic;
using Code.Common.Extensions;

namespace Code.Gameplay.Features.Armaments.Extensions
{
    public static class ArmamentEntityExtensions
    {
        private const int TARGET_BUFFER_CAPACITY = 16;

        public static GameEntity AddTargetCollecting(this GameEntity entity)
        {
            return entity
                .AddTargetsBuffer(new List<int>(TARGET_BUFFER_CAPACITY))
                .AddProcessedTargets(new List<int>(TARGET_BUFFER_CAPACITY))
                .With(x => x.isCollectingTargetContinuously = true);
        }

        public static GameEntity AddProducerFollow(this GameEntity entity, int producerId)
        {
            return entity
                .AddProducerId(producerId)
                .With(x => x.isFollowingProducer = true);
        }
    }
}