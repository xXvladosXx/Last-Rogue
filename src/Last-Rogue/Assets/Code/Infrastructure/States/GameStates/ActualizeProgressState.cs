using System;
using Code.Common.Entity;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Meta.Features.AfkGain.Configs;
using Code.Gameplay.Meta.Simulation;
using Code.Infrastructure.Progress.Data;
using Code.Infrastructure.Progress.Provider;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
    public class ActualizeProgressState : IState
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly IProgressProvider _progressProvider;
        private readonly ISystemFactory _systemFactory;
        private readonly ITimeService _timeService;

        private TimeSpan _twoDays = TimeSpan.FromDays(2);
        
        private ActualizationFeature _actualizationFeature;

        public ActualizeProgressState(IGameStateMachine stateMachine,
            IProgressProvider progressProvider,
            ISystemFactory systemFactory,
            ITimeService timeService)
        {
            _stateMachine = stateMachine;
            _progressProvider = progressProvider;
            _systemFactory = systemFactory;
            _timeService = timeService;
        }
        
        public void Enter()
        {
            _actualizationFeature = _systemFactory.Create<ActualizationFeature>();
            ActualizeProgress(_progressProvider.ProgressData);
            
            _stateMachine.Enter<LoadingHomeScreenState>();
        }

        private void ActualizeProgress(ProgressData progressData)
        {
            CreateMetaEntity.Empty()
                .AddGoldGainBoost(1)
                .AddDuration((float) TimeSpan.FromDays(2).TotalSeconds);
            
            _actualizationFeature.Initialize();
            var until = GetLimitedUntilTime(progressData);

            while (progressData.LastSimulationTickTime < until)
            {
                CreateMetaEntity.Empty()
                    .AddTick(AfkGainConfig.SIMULATION_TICK);
                
                _actualizationFeature.Execute();
                _actualizationFeature.Cleanup();
            }
            
            progressData.LastSimulationTickTime = _timeService.UtcNow;
        }

        public void Exit()
        {
            _actualizationFeature.Cleanup();
            _actualizationFeature.TearDown();
            _actualizationFeature = null;
        }

        private DateTime GetLimitedUntilTime(ProgressData progressData)
        {
            if (_timeService.UtcNow - progressData.LastSimulationTickTime < _twoDays)
            {
                return _timeService.UtcNow;
            }
            
            return progressData.LastSimulationTickTime + _twoDays;
        }
    }
}