using Logging;
using UnityEngine;

namespace Infrastructure.AssetProviding
{
    public class AssetProvider<T> : IAssetProvider<T>, IAssetLoader where T : Object
    {
        public T StaticData { get; private set; }

        private readonly AssetsPathProvider _assetsPaths;
        private readonly string _errorMessage;
        private string _path;

        public AssetProvider(AssetsPathProvider assetsPaths)
        {
            _assetsPaths = assetsPaths;
        }

        public AssetProvider(string assetsPaths, string errorMessage = "")
        {
            _path = assetsPaths;
            _errorMessage = errorMessage;
        }

        public void Load()
        {
            SelectPath();
            SetStatics();
        }

        private void SelectPath()
        {
            if (_assetsPaths != null)
            {
                _path = _assetsPaths.GetPath(typeof(T));
            }
        }

        private void SetStatics()
        {
            T loadedData = LoadStaticData();
            if (CheckForLoading(loadedData))
            {
                StaticData = loadedData;
            }
        }

        private T LoadStaticData() => Resources.Load<T>(_path);

        private bool CheckForLoading(T loadedData)
        {
            bool loaded = loadedData != null;
            if (!loaded)
            {
                ProjectLogger.LogError("Data not loaded of type: " + typeof(T).Name + " " + _errorMessage);
            }

            return loaded;
        }
    }
}