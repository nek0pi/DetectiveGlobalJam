using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : StateMachine
{
    [HideInInspector]
    public MovementController MovementController;

    private void Awake()
    {
        MovementController = GetComponent<MovementController>();
        currentState = new PlayerNormalState(this);
    }

    private void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(input);

        if (Input.GetKeyDown(KeyCode.E))
        {
            // do stuff
        }
    }

    private void Move(Vector2 input)
    {
        if (currentState != null)
            StartCoroutine(currentState.Move(input));
    }
}
