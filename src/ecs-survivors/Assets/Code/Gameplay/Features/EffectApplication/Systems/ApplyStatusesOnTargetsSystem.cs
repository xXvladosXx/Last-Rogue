using Code.Common.Extensions;
using Code.Gameplay.Features.Effects.Factory;
using Code.Gameplay.Features.Statuses.Factory;
using Entitas;

namespace Code.Gameplay.Features.EffectApplication.Systems
{
    public class ApplyStatusesOnTargetsSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly IStatusFactory _statusFactory;
        private readonly IGroup<GameEntity> _entities;

        public ApplyStatusesOnTargetsSystem(GameContext gameContext, 
            IStatusFactory statusFactory)
        {
            _gameContext = gameContext;
            _statusFactory = statusFactory;
            _entities = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.StatusSetups,
                    GameMatcher.TargetsBuffer));
        }
        
        public void Execute()
        {
            foreach (var entity in _entities)
            {
                foreach (var targetId in entity.TargetsBuffer)
                {
                    foreach (var setup in entity.StatusSetups)
                    {
                        _statusFactory.CreateStatus(setup, ProducerId(entity), targetId)
                            .With(x => x.isApplied = true);
                    }
                }
            }
        }

        private int ProducerId(GameEntity entity) => 
            entity.hasProducerId ? entity.ProducerId : entity.Id;
    }
}