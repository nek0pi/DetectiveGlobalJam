using System.Collections;
using UnityEngine;

public class PhoneManager : Singleton<PhoneManager>
{
    [SerializeField] private GameObject phoneScreenCanvas;
    public Animator phoneAnimator;

    public void OpenPhone()
    {
        phoneScreenCanvas.SetActive(true);
        phoneAnimator.SetBool("isOpened", true);
    }

    public void ClosePhone()
    {
        phoneAnimator.SetBool("isOpened", false);
        StartCoroutine("WaitAndClose");
    }

    private IEnumerator WaitAndClose()
    {
        yield return new WaitForSeconds(1.15f);
        phoneScreenCanvas.SetActive(false);
    }
}
