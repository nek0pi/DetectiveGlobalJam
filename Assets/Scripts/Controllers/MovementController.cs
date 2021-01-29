using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : StateMachine
{
    private void Awake()
    {
        currentState = new MovementNormalState(this);
    }

    private void Update()
    {
        // do stuff
    }
}
