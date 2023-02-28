public class StateMachine
{
    public State currentState { get; private set; }

    public void initialize(State startingState)
    {
        currentState = startingState;
        currentState.enter();
    }

    public void changeState(State newState)
    {
        currentState.exit();
        currentState = newState;
        currentState.enter();
    }
}
