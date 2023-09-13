using Data.StaticData.Movement;
using Infrastructure.AssetProviding;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Binding
{
    public class BootstrapInstaller : LifetimeScope
    {
        private IContainerBuilder _builder;

        protected override void Configure(IContainerBuilder builder)
        {
            _builder = builder;
            
            RegisterAssetServices();
            RegisterAssets();
        }

        private void RegisterAssetServices()
        {
            _builder.Register<AssetsPathProvider>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterAssets()
        {
            _builder.Register<AssetProvider<MovementStaticDataContainer>>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}