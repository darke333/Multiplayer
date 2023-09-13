using System;
using System.Collections.Generic;
using Data.StaticData.Movement;

namespace Infrastructure.AssetProviding
{
    public class AssetsPathProvider : IAssetsPathProvider
    {
        private readonly Dictionary<Type, string> StaticsPaths = new()
        {
            { typeof(MovementStaticDataContainer), "Data/CurrencyData/CurrencyStaticDataContainer" },
        };

        public string GetPath(Type type)
        {
            return StaticsPaths[type];
        }
    }
}