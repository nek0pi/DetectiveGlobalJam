using System.Collections;
using UnityEngine;

public class PhoneManager : Singleton<PhoneManager>
{
    [SerializeField] private GameObject phoneScreen;
    public Animator anim;
    private void Start()
    {
        phoneScreen.SetActive(true);
        //todo: change to false and call OpenPhone() from app
    }

    public void OpenPhone()
    {
        phoneScreen.SetActive(true);
        anim.SetBool("isOpened", true);
    }

    public void ClosePhone()
    {
        anim.SetBool("isOpened", false);
        StartCoroutine("WaitAndClose");
    }

    private IEnumerator WaitAndClose()
    {
        yield return new WaitForSeconds(1.15f);
        phoneScreen.SetActive(false);
    }
}
