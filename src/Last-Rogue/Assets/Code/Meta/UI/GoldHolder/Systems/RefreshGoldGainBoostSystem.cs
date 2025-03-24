using System.Collections.Generic;
using Code.Meta.UI.GoldHolder.Service;
using Entitas;

namespace Code.Meta.UI.GoldHolder.Systems
{
    public class RefreshGoldGainBoostSystem : ReactiveSystem<MetaEntity>, IInitializeSystem
    {
        private readonly IStorageUIService _storageUIService;
        private readonly IGroup<MetaEntity> _boosters;
        private readonly List<MetaEntity> _boostersBuffer = new(4);

        public RefreshGoldGainBoostSystem(MetaContext context, IStorageUIService storageUIService) : base(context)
        {
            _storageUIService = storageUIService;

            _boosters = context.GetGroup(MetaMatcher.GoldGainBoost);
        }

        public void Initialize() => 
            UpdateGoldGainBoost(_boosters.GetEntities(_boostersBuffer));

        protected override ICollector<MetaEntity> GetTrigger(IContext<MetaEntity> context) => 
            context.CreateCollector(MetaMatcher.GoldGainBoost.AddedOrRemoved());

        protected override bool Filter(MetaEntity entity) => true;

        protected override void Execute(List<MetaEntity> entities) => 
            UpdateGoldGainBoost(entities);

        private void UpdateGoldGainBoost(List<MetaEntity> entities)
        {
            var goldGainBoost = 0f;
            
            foreach (var entity in entities)
            {
                if (entity.hasGoldGainBoost)
                {
                    goldGainBoost += entity.GoldGainBoost;
                }
            }
            
            _storageUIService.UpdateGoldGainBoost(goldGainBoost);
        }
    }
}