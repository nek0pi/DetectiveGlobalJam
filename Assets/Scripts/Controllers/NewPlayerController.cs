using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : Singleton<NewPlayerController>
{
    public PlayerState currentPlayerState;
    private CharacterController characterController;
    private Coroutine characterCoroutine;

    public void Start()
    {
        InputManager.Instance.allNonIneractive += MoveCharacter;
        characterController = GetComponent<CharacterController>();
    }
    public void MoveCharacter(Vector3 position)
    {
        if (currentPlayerState == PlayerState.Moving)
        {
            Vector3 newPosition = new Vector3(Camera.main.ScreenToWorldPoint(position).x,
                    gameObject.transform.position.y, gameObject.transform.position.z);
            
            if (characterCoroutine != null)
                StopCoroutine(characterCoroutine);
            
            characterCoroutine = StartCoroutine(Moving(newPosition));
        }

    }

    public void MoveWorldSpaceCharacter(Vector3 position, Action action = null)
    {
        if (currentPlayerState == PlayerState.Moving)
        {
            Vector3 newPosition = new Vector3(position.x,
                    gameObject.transform.position.y, gameObject.transform.position.z);

            if (characterCoroutine != null)
                StopCoroutine(characterCoroutine);

            characterCoroutine = StartCoroutine(Moving(newPosition, action));
        }

    }
    public IEnumerator Moving(Vector3 position, Action action = null)
    {
        while (position != transform.position)
        {
            if (Vector3.Distance(position, transform.position) < .1f)
                transform.position = position;
            else transform.position = Vector3.MoveTowards(transform.position, position, .1f);
            yield return new WaitForEndOfFrame();
        }
        //action?.Invoke();
    }

}

public enum PlayerState
{
    Talking, Moving
}
