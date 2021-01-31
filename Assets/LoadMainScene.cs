using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMainScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LoadingManager.LoadLevel("MainMenuScene");
    }

}
