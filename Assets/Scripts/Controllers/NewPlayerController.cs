using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    public Action<RaycastHit> OnWalkEnd;
    public PlayerState currentPlayerState;
    private Coroutine characterCoroutine;
    private Animator characterAnimator;

    public void Start()
    {
        InputManager.Instance.allInteractive += MoveCharacter;
        InputManager.Instance.allNonIneractive += MoveCharacter;
        DialogueManager.Instance.onDialogueStarted += ChangeStateToDialog;
        DialogueManager.Instance.onDialogueHasFinished += ChangeStateToWalking;
        OnWalkEnd += GetInteraction;
        OnWalkEnd += hit => { characterAnimator.SetBool("isMoving", false); };
        characterAnimator = GetComponent<Animator>();
    }

    public void ChangeStateToDialog()
    {
        currentPlayerState = PlayerState.Talking;
    }

    public void ChangeStateToWalking()
    {
        currentPlayerState = PlayerState.Moving;
    }

    public void MoveCharacter(RaycastHit raycastHit)
    {
        if (Vector3.Distance(raycastHit.collider.transform.position, transform.position) > .1f)
        {
            MoveWorldSpaceCharacter(raycastHit.collider.transform.position, raycastHit);
        }
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

    public void MoveWorldSpaceCharacter(Vector3 position, RaycastHit hit)
    {
        if (currentPlayerState == PlayerState.Moving)
        {
            Vector3 newPosition = new Vector3(position.x,
                    gameObject.transform.position.y, gameObject.transform.position.z);

            if (characterCoroutine != null)
                StopCoroutine(characterCoroutine);

            characterCoroutine = StartCoroutine(Moving(newPosition, hit));
        }

    }
    public IEnumerator Moving(Vector3 position, RaycastHit hit)
    {
        characterAnimator.SetBool("isMoving", true);
        while (position != transform.position)
        {
            if (Vector3.Distance(position, transform.position) < .1f)
            {
                transform.position = position;
            }

            else
            {
                transform.position = Vector3.MoveTowards(transform.position, position, .1f);
            }
            yield return new WaitForEndOfFrame();
        }
        OnWalkEnd?.Invoke(hit);
    }

    public IEnumerator Moving(Vector3 position)
    {
        characterAnimator.SetBool("isMoving", true);
        while (position != transform.position)
        {
            if (Vector3.Distance(position, transform.position) < .1f)
                transform.position = position;
            else transform.position = Vector3.MoveTowards(transform.position, position, .1f);
            yield return new WaitForEndOfFrame();
        }
        OnWalkEnd?.Invoke(new RaycastHit());
    }

    public void GetInteraction(RaycastHit raycastHit)
    {
        if(raycastHit.collider.GetComponent<Interactive>() != null)
            raycastHit.collider.GetComponent<Interactive>().CallOnInteract();
    }

}

public enum PlayerState
{
    Talking, Moving
}
