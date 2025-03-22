﻿using Entitas;

namespace Code.Gameplay.Meta.Simulation.Systems
{
    public class BoosterDurationSystem : IExecuteSystem
    {
        private readonly IGroup<MetaEntity> _boosters;
        private readonly IGroup<MetaEntity> _tick;

        public BoosterDurationSystem(MetaContext meta)
        {
            _tick = meta.GetGroup(MetaMatcher.Tick);
            
            _boosters = meta.GetGroup(MetaMatcher
                .AllOf(MetaMatcher.GoldGainBoost, 
                    MetaMatcher.Duration));
        }

        public void Execute()
        {
            foreach (var booster in _boosters)
            {
                foreach (var tick in _tick)
                {
                    booster.ReplaceDuration(booster.Duration - tick.Tick);

                    if (booster.Duration <= 0)
                    {
                        booster.isDestructed = true;
                    }
                }
            }
        }
    }
}