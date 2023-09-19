using UnityEngine;

namespace Data.StaticData.Movement
{
    [CreateAssetMenu(fileName = "MovementStaticDataContainer",
        menuName = "ScriptableObjects/Gameplay/MovementStaticDataContainer")]
    public class MovementStaticDataContainer : ScriptableObject
    {
        public float MovementSpeed => _movementSpeed;
        public float JumpHeight => _jumpHeight;
        public float DodgeDistance => _dodgeDistance;
        public float DodgeSpeed => _dodgeSpeed;

        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _dodgeDistance;
        [SerializeField] private float _dodgeSpeed;
    }
}