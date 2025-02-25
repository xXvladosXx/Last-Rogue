﻿using Code.Common.Extensions;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Enemies.Factory;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemySpawnSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IEnemyFactory _enemyFactory;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _timers;
        private readonly IGroup<GameEntity> _heroes;

        private const float SPAWN_DISTANCE_GAP = 0.5f;

        public EnemySpawnSystem(GameContext game, ITimeService timeService,
            IEnemyFactory enemyFactory, ICameraProvider cameraProvider)
        {
            _timeService = timeService;
            _enemyFactory = enemyFactory;
            _cameraProvider = cameraProvider;

            _timers = game.GetGroup(GameMatcher.SpawnTimer);
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (var hero in _heroes)
            {
                foreach (GameEntity timer in _timers)
                {
                    timer.ReplaceSpawnTimer(timer.SpawnTimer - _timeService.DeltaTime);
                    if (timer.SpawnTimer <= 0)
                    {
                        timer.ReplaceSpawnTimer(StaticDataService.ENEMY_SPAWN_TIMER);
                        _enemyFactory.CreateEnemy(EnemyTypeId.Goblin, RandomSpawnPosition(hero.WorldPosition));
                    }
                }
            }
        }

        private Vector2 RandomSpawnPosition(Vector2 aroundPosition)
        {
            bool startWithHorizontal = Random.Range(0, 2) == 0;

            return startWithHorizontal
                ? HorizontalSpawnPosition(aroundPosition)
                : VerticalSpawnPosition(aroundPosition);
        }

        private Vector2 HorizontalSpawnPosition(Vector2 aroundPosition)
        {
            Vector2[] horizontalDirections = { Vector2.left, Vector2.right };
            Vector2 primaryDirection = horizontalDirections.PickRandom();

            float horizontalOffsetDistance = _cameraProvider.WorldScreenWidth / 2 + SPAWN_DISTANCE_GAP;
            float verticalRandomOffset = Random.Range(-_cameraProvider.WorldScreenHeight / 2, _cameraProvider.WorldScreenHeight / 2);

            return aroundPosition + primaryDirection * horizontalOffsetDistance + Vector2.up * verticalRandomOffset;
        }

        private Vector2 VerticalSpawnPosition(Vector2 aroundPosition)
        {
            Vector2[] verticalDirections = { Vector2.up, Vector2.down };
            Vector2 primaryDirection = verticalDirections.PickRandom();

            float verticalOffsetDistance = _cameraProvider.WorldScreenHeight / 2 + SPAWN_DISTANCE_GAP;
            float horizontalRandomOffset = Random.Range(-_cameraProvider.WorldScreenWidth / 2, _cameraProvider.WorldScreenWidth / 2);

            return aroundPosition + primaryDirection * verticalOffsetDistance + Vector2.right * horizontalRandomOffset;
        }
    }
}