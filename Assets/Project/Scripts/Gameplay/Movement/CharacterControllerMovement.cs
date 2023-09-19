using Data.StaticData.Movement;
using Infrastructure.AssetProviding;
using Input;
using UnityEngine;
using VContainer;

namespace Movement
{
    public class CharacterControllerMovement : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;

        private IInputActions _inputActions;
        private AssetProvider<MovementStaticDataContainer> _assetProviderMovement;

        private MovementStaticDataContainer _movementStaticDataContainer => _assetProviderMovement.StaticData;
        private Vector3 _playerVelocity;
        
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
            _playerVelocity.y += Mathf.Sqrt(_movementStaticDataContainer.JumpHeight * Physics.gravity.y);

            _characterController.Move(_playerVelocity);
        }

        private void Move(Vector2 direction)
        {
            _playerVelocity.x = direction.x;
            _playerVelocity.z = direction.y;
            _characterController.Move(_playerVelocity);
        }
    }
}