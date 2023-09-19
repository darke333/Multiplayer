using Data.StaticData.Movement;
using Data.StaticData.Player;
using Infrastructure.AssetProviding;
using Infrastructure.GameStateMachine;
using Infrastructure.GameStateMachine.States;
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
            RegisterStates();
        }

        private void RegisterStates()
        {
            _builder.Register<EntryPoint>(Lifetime.Singleton).As<IInitializable>();
            _builder.Register<GameStateMachine.GameStateMachine>(Lifetime.Singleton);
            
            _builder.Register<LoadStaticState>(Lifetime.Transient).AsImplementedInterfaces();
            _builder.Register<PrewarmGameplayState>(Lifetime.Transient).AsImplementedInterfaces();
        }
        
        private void RegisterAssetServices()
        {
            _builder.Register<AssetsPathProvider>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void RegisterAssets()
        {
            
            _builder.Register<AssetProvider<MovementStaticDataContainer>>(Lifetime.Singleton).AsImplementedInterfaces();
            _builder.Register<AssetProvider<PlayerStaticDataContainer>>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}