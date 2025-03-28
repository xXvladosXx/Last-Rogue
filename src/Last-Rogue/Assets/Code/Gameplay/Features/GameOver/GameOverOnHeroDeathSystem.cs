﻿using System.Collections.Generic;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using Entitas;

namespace Code.Gameplay.Features.GameOver
{
    public class GameOverOnHeroDeathSystem : ReactiveSystem<GameEntity>
    {
        private readonly IGameStateMachine _gameStateMachine;

        public GameOverOnHeroDeathSystem(GameContext gameContext, 
            IGameStateMachine gameStateMachine)
            : base(gameContext)
        {
            _gameStateMachine = gameStateMachine;
        }
       
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) => 
            context.CreateCollector(GameMatcher
                .AllOf(GameMatcher.Hero,
                    GameMatcher.Dead)
                .Added());

        protected override bool Filter(GameEntity entity) => entity.isDead;

        protected override void Execute(List<GameEntity> heroes)
        {
            _gameStateMachine.Enter<GameOverState>();
        }
    }
}