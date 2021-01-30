using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportManager : MonoBehaviour
{
    private Locations _currentLocation;

    public enum Locations
    {
        City,
        Bar,
        Appartment
    }

    public void TransportPlayer(Locations targetLocation)
    {
        //SceneManager.LoadSceneAsync(targetLocation, LoadSceneMode.Single);
    }

    public void FillDialogueOptions()
    {
        // fills in dialog options into yarn dialogue system using available locations

        // TODO: Connect Vlad's interface
    }
}
