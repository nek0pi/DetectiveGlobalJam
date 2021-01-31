using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    public GameObject targetPoint, player;
    void Start()
    {
        DialogueManager.Instance.onGoingUpstairs += TeleportPlayer;
    }

    private void TeleportPlayer()
    {
        player.transform.position = targetPoint.transform.position;
    }
}
