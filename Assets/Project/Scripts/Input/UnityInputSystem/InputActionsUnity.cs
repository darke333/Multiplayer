using System;
using UnityEngine;

namespace Input.UnityInputSystem
{
    public class InputActionsUnity : IInputActions
    {
        public new event Action Jump;
        public new event Action Dodge;
        public new event Action<Vector2> Movement;

        private readonly InputHub _inputHub;

        public InputActionsUnity(InputHub inputHub)
        {
            _inputHub = inputHub;

            ConnectToEvents();
        }

        private void ConnectToEvents()
        {
            _inputHub.CharacterMove.Dodge.performed += _ => Dodge?.Invoke();
            _inputHub.CharacterMove.Dodge.performed += _ => Jump?.Invoke();
            _inputHub.CharacterMove.Movement.performed += (context) => Movement?.Invoke(context.ReadValue<Vector2>());
        }
    }
}