using Code.Gameplay.Features.Enemies.Factory;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Input.Service;
using Code.Gameplay.StaticData;
using Code.Infrastructure;
using Entitas;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Loot.Systems
{
    public class CollectWhenNearSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _pullables;
        private readonly IGroup<GameEntity> _heroes;

        private const float CLOSE_DISTANCE = 1;

        public CollectWhenNearSystem(GameContext game)
        {
            _pullables = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Pulling,
                    GameMatcher.WorldPosition));
            
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity pullable in _pullables)
            {
                foreach (var hero in _heroes)
                {
                    if (Vector3.Distance(hero.WorldPosition, pullable.WorldPosition) < CLOSE_DISTANCE)
                    {
                        pullable.isCollected = true;
                    }
                }
            }
        }
    }
}