using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNormalState : State
{
    public PlayerNormalState(PlayerController _playerController) : base(_playerController) { }

    public override IEnumerator Move(Vector2 inp)
    {
        _playerController.MovementController.Move(inp);
        yield break;
    }
}
