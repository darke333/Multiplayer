using Logging;
using UnityEngine;

namespace Infrastructure.AssetProviding.Hub
{
    public class AssetProviderFromHub<T> : IAssetProvider<T>, IAssetLoader where T : ScriptableObject
    {
        public T StaticData { get; private set; }
        private readonly IAssetsHub _assetsHub;

        public AssetProviderFromHub(IAssetsHub assetsHub)
        {
            _assetsHub = assetsHub;
        }

        public void Load()
        {
            SetStatics();
        }

        private void SetStatics()
        {
            T loadedData = LoadStaticData();
            if (CheckForLoading(loadedData))
            {
                StaticData = loadedData;
            }
        }

        private T LoadStaticData() => _assetsHub.GetAsset<T>(typeof(T));

        private bool CheckForLoading(T loadedData)
        {
            bool loaded = loadedData != null;
            if (!loaded)
            {
                ProjectLogger.LogError("Data not loaded of type: " + typeof(T).Name);
            }

            return loaded;
        }
    }
}