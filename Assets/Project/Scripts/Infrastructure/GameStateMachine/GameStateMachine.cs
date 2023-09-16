using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.GameStateMachine
{
    public class GameStateMachine
    {
        private readonly IReadOnlyList<IState> _states;
        private IState _activeState;

        public GameStateMachine(IReadOnlyList<IState> states)
        {
            _states = states;
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            if (state != null && _activeState is IStateChangeable)
            {
                (state as IStateChangeable).SetStateMachine(this);
            }
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload Payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(Payload);
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            if (_activeState != null && _activeState is IStateExitable)
            {
                (_activeState as IStateExitable).Exit();
            }

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState =>
            (TState)_states.First(s => s.GetType() == typeof(TState));
    }
}