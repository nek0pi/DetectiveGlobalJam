using System.Collections;
using UnityEngine;

public abstract class State
{
    protected readonly PlayerController _playerController;

    public State(PlayerController pc)
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
