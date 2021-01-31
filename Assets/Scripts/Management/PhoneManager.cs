using System;
using System.Collections;
using UnityEngine;

public class PhoneManager : Singleton<PhoneManager>
{
    [SerializeField] private GameObject phoneScreenCanvas;
    public Animator phoneAnimator;
    public Action OnShow;
    public Action OnHide;

    public void OpenPhone()
    {
        OnShow?.Invoke();
        phoneScreenCanvas.SetActive(true);
        phoneAnimator.SetBool("isOpened", true);
    }

    public void ClosePhone()
    {
        OnHide.Invoke();
        phoneAnimator.SetBool("isOpened", false);
        StartCoroutine(WaitAndClose());
    }

    private IEnumerator WaitAndClose()
    {
        yield return new WaitForSeconds(1f);
        phoneScreenCanvas.SetActive(false);
    }
}
