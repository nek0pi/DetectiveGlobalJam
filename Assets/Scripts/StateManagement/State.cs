using System.Collections;
using UnityEngine;

public abstract class State
{
    protected readonly PlayerContoller _playerController;

    public State(PlayerContoller pc)
    {
        _playerController = pc;
    }

    public virtual IEnumerator StartState()
    {
        yield break;
    }

    public virtual IEnumerator ExitState()
    {
        yield break;
    }

    public virtual IEnumerator Move(Vector2 input)
    {
        yield break;
    }

    public virtual IEnumerator Interact()
    {
        yield break;
    }
}
