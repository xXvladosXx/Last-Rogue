using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
    public class CleanupProcessedEffectSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _effects;
        private readonly List<GameEntity> _buffer = new(32);

        public CleanupProcessedEffectSystem(GameContext contextParameter)
        {
            _effects = contextParameter.GetGroup(GameMatcher
                .AllOf(GameMatcher.Effect,
                    GameMatcher.Processed));
        }

        public void Cleanup()
        {
            foreach (GameEntity effect in _effects.GetEntities(_buffer))
            {
                effect.Destroy();
            }
        }
    }
}