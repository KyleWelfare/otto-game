public class StateMachine
{
    public State currentState { get; private set; }

    public void Initialize(State startingState)
    {
        currentState = startingState;
        currentState.enter();
    }

    public void ChangeState(State newState)
    {
        currentState.exit();
        currentState = newState;
        currentState.enter();
    }
}
