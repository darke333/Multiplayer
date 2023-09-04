using Input;
using UnityEngine;
using VContainer;

namespace Movement
{
    public class CharacterControllerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        
        private IInputActions _inputActions;
        
        private Vector3 _playerVelocity;
        
        //private readonly Vector3 _gravity = Physics.gravity;

        [Inject]
        private void Constructor(IInputActions inputActions)
        {
            _inputActions = inputActions;

            ConnectToEvents();
        }

        private void ConnectToEvents()
        {
            _inputActions.Movement += Move;
            _inputActions.Jump += Jump;
        }

        private void Jump()
        {
            
            //_playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * Physics.gravity);

            //_characterController
        }

        private void Move(Vector2 direction)
        {
            //_characterController.Move();
        }
        
    }
}