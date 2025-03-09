using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Indexing;
using Entitas;
using Zenject;

namespace Code.Common.EntityIndices
{
    public class GameEntityIndices : IInitializable
    {
        private readonly GameContext _gameContext;
        public const string STATUSES_OF_TYPE = "StatusesOfType";

        public GameEntityIndices(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        
        public void Initialize()
        {
            _gameContext.AddEntityIndex(new EntityIndex<GameEntity, StatusKey>(STATUSES_OF_TYPE,
                _gameContext.GetGroup(GameMatcher.AllOf(GameMatcher.StatusTypeId,
                    GameMatcher.TargetId,
                    GameMatcher.Status,
                    GameMatcher.Duration,
                    GameMatcher.TimerLeft)), 
                GetTargetStatusKey,
                new StatusKeyEqualityComparer()));
        }

        private StatusKey GetTargetStatusKey(GameEntity entity, IComponent component)
        {
            return new StatusKey(
                (component as TargetId)?.Value ?? entity.TargetId,
                (component as StatusTypeIdComponent)?.Value ?? entity.StatusTypeId);
        }
    }
    
    public static class ContextIndicesExtension
    {
        public static HashSet<GameEntity> TargetStatusesOfType(this GameContext context, StatusTypeId statusTypeId, int targetId)
        {
            return ((EntityIndex<GameEntity, StatusKey>)context.GetEntityIndex(GameEntityIndices.STATUSES_OF_TYPE))
                .GetEntities(new StatusKey(targetId, statusTypeId));
        }
    }
}