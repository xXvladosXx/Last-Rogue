using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
    public class CleanupUnappliedStatusLinkedChanges : ICleanupSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _group;
        private readonly List<GameEntity> _buffer = new(32);

        public CleanupUnappliedStatusLinkedChanges(GameContext game)
        {
            _game = game;
            _group = game.GetGroup(GameMatcher.AllOf(GameMatcher.Id,
                GameMatcher.Status,
                GameMatcher.Unapplied));
        }

        public void Cleanup()
        {
            foreach (GameEntity status in _group.GetEntities(_buffer))
            {
                foreach (var entity in _game.GetEntitiesWithApplierStatusLink(status.Id))
                {
                    entity.isDestructed = true;
                }
            }
        }
    }
}