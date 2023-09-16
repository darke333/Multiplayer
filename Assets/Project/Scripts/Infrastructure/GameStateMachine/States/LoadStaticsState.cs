using System.Collections.Generic;
using Infrastructure.AssetProviding;

namespace Infrastructure.GameStateMachine.States
{
    public class LoadStaticState : IState, IStateChangeable
    {
        private readonly IReadOnlyList<IAssetLoader> _assetLoaders;

        private GameStateMachine _stateMachine;
        
        public LoadStaticState(IReadOnlyList<IAssetLoader> assetLoaders)
        {
            _assetLoaders = assetLoaders;
        }
        
        public void Enter()
        {
            LoadData();
            _stateMachine.Enter<PrewarmGameplayState>();
        }

        public void SetStateMachine(GameStateMachine gameStateMachine)
        {
            _stateMachine = gameStateMachine;
        }

        private void LoadData()
        {
            LoadStaticData();
        }

        private void LoadStaticData()
        {
            foreach (IAssetLoader assetLoader in _assetLoaders)
            {
                assetLoader.Load();
            }
        }
    }
}