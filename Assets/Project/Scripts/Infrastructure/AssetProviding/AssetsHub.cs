using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.AssetProviding
{
    public class AssetsHub : MonoBehaviour, IAssetsHub
    {
        private Dictionary<Type, ScriptableObject> TypeToSO = new();
    }
}