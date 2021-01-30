using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Interactive : MonoBehaviour
{
    [SerializeField] public int dialogIndex;
    public void Start()
    {
        InputManager.Instance.allInteractive += OnHit;
    }

    public abstract void CallDialogue(int index);
    public abstract void OnHit(RaycastHit raycastHit);
}
