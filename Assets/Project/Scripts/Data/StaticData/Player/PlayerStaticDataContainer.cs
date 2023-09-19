using UnityEngine;

namespace Data.StaticData.Player
{
    [CreateAssetMenu(fileName = "PlayerStaticDataContainer",
        menuName = "ScriptableObjects/Gameplay/PlayerStaticDataContainer")]
    public class PlayerStaticDataContainer : ScriptableObject
    {
        public GameObject PlayerGameObject => _playerGameObject;
        
        [SerializeField] private GameObject _playerGameObject;
    }
}