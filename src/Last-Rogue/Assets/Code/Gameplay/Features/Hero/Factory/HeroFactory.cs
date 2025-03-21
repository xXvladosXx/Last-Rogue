using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
    public class HeroFactory : IHeroFactory
    {
        private readonly IIdentifierService _identifierService;

        public HeroFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }

        public GameEntity CreateHero(Vector2 at)
        {
            var baseStats = InitStats.EmptyStatDictionary()
                .With(x => x[Stats.MaxHealth] = 100)
                .With(x => x[Stats.Speed] = 2);
            
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddWorldPosition(at)
                .AddBaseStats(baseStats)
                .AddStatModifiers(InitStats.EmptyStatDictionary())
                .AddSpeed(baseStats[Stats.Speed])
                .AddDirection(Vector2.zero)
                .AddCurrentHP(baseStats[Stats.MaxHealth])
                .AddMaxHP(baseStats[Stats.MaxHealth])
                .AddExperience(0)
                .AddPickupRadius(1)
                .AddViewPath("Gameplay/Hero/hero")
                .With(x => x.isHero = true)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true);
        }
    }
}