using System;
using System.Collections.Generic;
using Data.StaticData.Movement;
using Data.StaticData.Player;

namespace Infrastructure.AssetProviding
{
    public class AssetsPathProvider : IAssetsPathProvider
    {
        private readonly Dictionary<Type, string> _staticsPaths = new()
        {
            { typeof(MovementStaticDataContainer), "Data/Movement/MovementStaticDataContainer" },
            { typeof(PlayerStaticDataContainer), "Data/Player/PlayerStaticDataContainer" },
        };

        public string GetPath(Type type)
        {
            return _staticsPaths[type];
        }
    }
}