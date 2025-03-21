using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class OrbitalDeltaMoveSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _movers;

        public OrbitalDeltaMoveSystem(GameContext gameContext, ITimeService timeService)
        {
            _timeService = timeService;
            _movers = gameContext.GetGroup(GameMatcher
                .AllOf(GameMatcher.WorldPosition,
                    GameMatcher.OrbitPhase,
                    GameMatcher.OrbitCenterPosition,
                    GameMatcher.OrbitRadius,
                    GameMatcher.Speed,
                    GameMatcher.Moving,
                    GameMatcher.MovementAvailable));
        }
        
        public void Execute()
        {
            foreach (var mover in _movers)
            {
                var phase = mover.OrbitPhase + _timeService.DeltaTime * mover.Speed;
                mover.ReplaceOrbitPhase(phase);
                
                var newRelativePosition = new Vector3(Mathf.Cos(phase), Mathf.Sin(phase), 0) * mover.OrbitRadius;
                var newPosition = newRelativePosition + mover.OrbitCenterPosition;
                mover.ReplaceWorldPosition(newPosition);
            }
        }
    }
}