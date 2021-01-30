using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : Singleton<LoadingManager>
{
    [SerializeField] GameObject levelTransition;
    [SerializeField] string fadeIn;
    [SerializeField] string fadeOut;
    [SerializeField] bool needToFadeOut;
    
    public void OnLevelWasLoaded(int level)
    {
        if(needToFadeOut)
            PlayAnimation(fadeOut);
    }
    public static void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public AnimatorStateInfo PlayAnimation(string animName)
    {
        levelTransition.GetComponent<Animator>().Play(animName, 0);
        AnimatorStateInfo animInfo = levelTransition.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        return animInfo;
    }

    IEnumerator WaitLoading(float timer, string levelName)
    {
        //Mhe
        yield return new WaitForSeconds(timer);
        LoadLevel(levelName);
    }
    public void PlayLevelTransition(string levelName)
    {
        StartCoroutine(WaitLoading(PlayAnimation(fadeIn).length, levelName));
    }
}
