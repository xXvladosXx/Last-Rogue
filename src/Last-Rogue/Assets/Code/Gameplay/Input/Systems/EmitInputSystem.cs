﻿using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        
        private readonly IGroup<InputEntity> _inputs;

        public EmitInputSystem(InputContext inputContext, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = inputContext.GetGroup(InputMatcher.Input);
        }
        
        public void Execute()
        {
            foreach (var input in _inputs)
            {
                if (_inputService.HasAxisInput())
                {
                    input.ReplaceAxisInput(new Vector2(_inputService.GetHorizontalAxis(), _inputService.GetVerticalAxis()));
                }
                else if (input.hasAxisInput)
                {
                    input.RemoveAxisInput();
                }
            }    
        }
    }
}