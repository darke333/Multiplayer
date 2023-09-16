using System.Collections.Generic;

namespace Infrastructure.GameStateMachine.States
{
    public class PrewarmGameplayState : IState
    {
        private readonly IReadOnlyList<IInitializablePrewarm> _prewarms;
        
        public PrewarmGameplayState(IReadOnlyList<IInitializablePrewarm> prewarms)
        {
            _prewarms = prewarms;
        }

        public void Enter()
        {
            InitSystems();
        }

        public void Exit()
        {
            EnterGameplay();
        }

        private void InitSystems()
        {
            foreach (IInitializablePrewarm prewarm in _prewarms)
            {
                prewarm.Initialize();
            }
        }

        private void EnterGameplay()
        {
        }
    }
}