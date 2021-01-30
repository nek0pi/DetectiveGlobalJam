using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    public State currentState;

    public void SetState(State state)
    {
        if (currentState != null)
            StartCoroutine(currentState.ExitState());
        currentState = state;
        StartCoroutine(currentState.StartState());
    }
}
