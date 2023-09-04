using System;
using System.Collections.Generic;
using Data.StaticData.AssetHub;
using Data.StaticData.Movement;
using UnityEngine;

namespace Infrastructure.AssetProviding.Hub
{
    public class AssetsHubProvider : IAssetsHub, IAssetsHubFiller
    {
        private readonly IAssetProvider<AssetsHubStaticContainer> _assetProvider;

        private Dictionary<Type, ScriptableObject> TypeToSO = new();
        private AssetsHubStaticContainer _assetsHubStaticContainer => _assetProvider.StaticData;

        public AssetsHubProvider(IAssetProvider<AssetsHubStaticContainer> assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void FillHub()
        {
            TypeToSO.Add(typeof(MovementStaticDataContainer), _assetsHubStaticContainer.MovementStaticDataContainer);
        }

        public T GetAsset<T>(Type type) where T : ScriptableObject
        {
            return (T)TypeToSO[type];
        }
    }
}