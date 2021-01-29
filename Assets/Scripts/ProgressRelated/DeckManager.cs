using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour, ISubscriber
{
    // Start is called before the first frame update
    void Start()
    {
        ProgressManager.instance.AddSubscriber(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetUpdate(int id)
    {
        throw new System.NotImplementedException();
    }
}
