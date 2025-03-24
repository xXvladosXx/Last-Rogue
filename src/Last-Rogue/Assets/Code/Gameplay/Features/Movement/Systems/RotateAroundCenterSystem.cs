using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class RotateAroundCenterSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _rotators;
        private readonly ITimeService _time;

        public RotateAroundCenterSystem(GameContext game, ITimeService time)
        {
            _time = time;
            _rotators = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RotatesAroundCenter,
                    GameMatcher.AngleSpeed,
                    GameMatcher.Transform));
        }

        public void Execute()
        {
            foreach (GameEntity rotator in _rotators)
            {
                rotator.Transform.Rotate(Vector3.forward, rotator.AngleSpeed * _time.DeltaTime);
            }
        }
    }
}