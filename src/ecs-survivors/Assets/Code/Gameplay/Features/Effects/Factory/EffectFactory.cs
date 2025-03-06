using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Effects.Factory
{
    public class EffectFactory
    {
        private readonly IIdentifierService _identifierService;

        public EffectFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
    }
}