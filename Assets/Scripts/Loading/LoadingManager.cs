using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;
    [SerializeField] GameObject levelTransition;
    [SerializeField] string fadeIn;
    [SerializeField] string fadeOut;
    [SerializeField] bool needToFadeOut;
    [SerializeField] string managerLevelName;

    public void Start()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    
    
    public void OnLevelWasLoaded(int level)
    {
        if(needToFadeOut)
            PlayAnimation(fadeOut);

        if (SceneManager.GetActiveScene().name != "MainMenuScene")
            SceneManager.LoadScene(managerLevelName, LoadSceneMode.Additive);

    }
    
    
    public static void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public static void LoadLevelAdditive(string levelname)
    {
        SceneManager.LoadScene(levelname, LoadSceneMode.Additive);
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
