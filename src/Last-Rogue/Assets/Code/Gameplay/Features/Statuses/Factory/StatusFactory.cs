using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enchants;
using Code.Infrastructure.Identifiers;
using Unity.VisualScripting;

namespace Code.Gameplay.Features.Statuses.Factory
{
    public class StatusFactory : IStatusFactory
    {
        private readonly IIdentifierService _identifierService;

        public StatusFactory(IIdentifierService identifierService)
        {
            _identifierService = identifierService;
        }
        
        public GameEntity CreateStatus(StatusSetup statusSetup, int producerId, int targetId)
        {
            GameEntity status = null;
            switch (statusSetup.StatusTypeId)
            {
                case StatusTypeId.Unknown:
                    break;
                case StatusTypeId.Poison:
                    status = CreatePoison(statusSetup, producerId, targetId);
                    break;
                case StatusTypeId.Freeze:
                    status = CreateFreeze(statusSetup, producerId, targetId);
                    break;
                case StatusTypeId.PoisonEnchant:
                    status = CreatePoisonEnchant(statusSetup, producerId, targetId);
                    break;
                case StatusTypeId.ExplosiveEnchant:
                    status = CreateExplosiveEnchant(statusSetup, producerId, targetId);
                    break;
            }

            status.With(x => x.AddDuration(statusSetup.Duration), statusSetup.Duration > 0);
            status.With(x => x.AddTimerLeft(statusSetup.Duration), statusSetup.Duration > 0);
            status.With(x => x.AddPeriod(statusSetup.Period), statusSetup.Period > 0);
            status.With(x => x.AddTimeSinceLastTick(0), statusSetup.Period > 0);
            
            return status;
         }

        private GameEntity CreatePoison(StatusSetup statusSetup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isStatus = true)
                .AddStatusTypeId(StatusTypeId.Poison)
                .AddEffectValue(statusSetup.Value)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.isPoison = true);
        }

        private GameEntity CreateFreeze(StatusSetup statusSetup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .With(x => x.isStatus = true)
                .AddStatusTypeId(StatusTypeId.Freeze)
                .AddEffectValue(statusSetup.Value)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.isFreeze = true);
        }

        private GameEntity CreatePoisonEnchant(StatusSetup statusSetup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddStatusTypeId(StatusTypeId.PoisonEnchant)
                .AddEnchantTypeId(EnchantTypeId.PoisonArmaments)
                .AddEffectValue(statusSetup.Value)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.isStatus = true)
                .With(x => x.isPoisonEnchant = true);
        }

        private GameEntity CreateExplosiveEnchant(StatusSetup statusSetup, int producerId, int targetId)
        {
            return CreateEntity.Empty()
                .AddId(_identifierService.Next())
                .AddStatusTypeId(StatusTypeId.ExplosiveEnchant)
                .AddEnchantTypeId(EnchantTypeId.ExplosiveArmaments)
                .AddEffectValue(statusSetup.Value)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.isStatus = true)
                .With(x => x.isExplosiveEnchant = true);
        }
    }
}