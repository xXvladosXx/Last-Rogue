using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    public class CastForTargetsNoLimitSystem : IExecuteSystem
    {
        private readonly IPhysicsService _physicsService;
        private readonly IGroup<GameEntity> _ready;
        private readonly List<GameEntity> _buffer = new(64);

        public CastForTargetsNoLimitSystem(GameContext gameContext, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _ready = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.ReadyToCollectTargets,
                    GameMatcher.TargetsBuffer,
                    GameMatcher.WorldPosition,
                    GameMatcher.Radius,
                    GameMatcher.LayerMask)
                .NoneOf(GameMatcher.TargetLimit));
        }
        
        public void Execute()
        {
            foreach (var entity in _ready.GetEntities(_buffer))
            {
                var targetsInRadius = TargetsInRadius(entity);
                entity.TargetsBuffer.AddRange(targetsInRadius);
                
                if (!entity.isCollectingTargetContinuously)
                    entity.isReadyToCollectTargets = false;
            }
        }

        private IEnumerable<int> TargetsInRadius(GameEntity entity) =>
            _physicsService
                .CircleCast(entity.WorldPosition, entity.Radius, entity.LayerMask)
                .Where(x => !x.isDead)
                .Select(x => x.Id);
    }
}