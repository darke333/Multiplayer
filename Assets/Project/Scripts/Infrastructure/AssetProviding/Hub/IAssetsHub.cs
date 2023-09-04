using System;
using UnityEngine;

namespace Infrastructure.AssetProviding.Hub
{
    public interface IAssetsHub
    {
        public T GetAsset<T>(Type type) where T : ScriptableObject;
    }
}