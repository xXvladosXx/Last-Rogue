using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class UpdateHealthBarSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _healthBars;

        public UpdateHealthBarSystem(GameContext game)
        {
            _healthBars = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.HealthBar));

            _heroes = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.CurrentHP,
                    GameMatcher.MaxHP));
        }

        public void Execute()
        {
            foreach (var healthBar in _healthBars)
            {
                foreach (var hero in _heroes)
                {
                    healthBar.HealthBar.SetHealth(hero.CurrentHP, hero.MaxHP);
                }
            }
        }
    }
}