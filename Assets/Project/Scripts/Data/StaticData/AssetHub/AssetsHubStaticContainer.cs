using Data.StaticData.Movement;
using UnityEngine;

namespace Data.StaticData.AssetHub
{
    public class AssetsHubStaticContainer : ScriptableObject
    {
        public MovementStaticDataContainer MovementStaticDataContainer => _movementStaticDataContainer;
        
        [SerializeField] private MovementStaticDataContainer _movementStaticDataContainer;
    }
}