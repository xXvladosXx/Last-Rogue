using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Meta.Features.Simulation.Systems
{
    public class CalculateGoldGainSystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IGroup<MetaEntity> _boosters;
        private readonly IGroup<MetaEntity> _storages;

        public CalculateGoldGainSystem(MetaContext meta
            , IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _boosters = meta.GetGroup(MetaMatcher.GoldGainBoost);
            _storages = meta.GetGroup(MetaMatcher
                .AllOf(MetaMatcher.Storage, 
                    MetaMatcher.GoldPerSecond));
        }

        public void Execute()
        {
            foreach (var booster in _boosters)
            {
                var gainBonus = 1f;
                gainBonus += booster.GoldGainBoost;

                foreach (var storage in _storages)
                {
                    storage.ReplaceGoldPerSecond(_staticDataService.AfkGainConfig.GainGoldPerSecond * gainBonus);
                }
            }
        }
    }
}