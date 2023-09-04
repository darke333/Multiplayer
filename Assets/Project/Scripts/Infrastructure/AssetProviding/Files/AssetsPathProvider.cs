using System;
using System.Collections.Generic;
using Data.StaticData.AssetHub;

namespace Infrastructure.AssetProviding
{
    public class AssetsPathProvider
    {
        public readonly Dictionary<Type, string> StaticsPaths = new()
        {
            { typeof(AssetsHubStaticContainer), "Data/CurrencyData/CurrencyStaticDataContainer" },
        };
    }
}