using Code.Common.Extensions;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemySelfExplosionSystem : IExecuteSystem
    {
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;

        private const float DISTANCE_TO_EXPLODE = 1f;

        public EnemySelfExplosionSystem(GameContext game,
            IArmamentFactory armamentFactory)
        {
            _armamentFactory = armamentFactory;
            
            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.WorldPosition));
            
            _enemies = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Enemy,
                    GameMatcher.WorldPosition,
                    GameMatcher.EnemySelfExploded)
                .NoneOf(GameMatcher.ProcessingDeath,
                    GameMatcher.Dead));
        }

        public void Execute()
        {
            var enemies = _enemies.GetEntities();
            var heroes = _heroes.GetEntities();

            foreach (var enemy in enemies)
            {
                foreach (var hero in heroes)
                {
                    var distance = (hero.WorldPosition - enemy.WorldPosition).magnitude;
                    
                    if (distance < DISTANCE_TO_EXPLODE)
                    {
                        enemy.isReached = true;
                        
                        enemy.isDead = true;
                        enemy.isProcessingDeath = true;
                        
                        _armamentFactory.CreateExplosion(enemy.Id, enemy.WorldPosition, CollisionLayer.Hero);
                    }
                }
            }
        }
    }
}