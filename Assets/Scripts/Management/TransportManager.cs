using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportManager : Singleton<TransportManager>
{
    private Locations currentLocation;

    public enum Locations
    {
        House = 2,
        DaughterRoom = 3,
        Bar = 4,
        Slums = 5,
        Apartment = 6,
        Bridge = 7,
        Hideout = 8,
        MainScene = 9
    }
    public void TaxiDialogueStart()
    {
        DialogueManager.Instance.StartDialogue(DialogueManager.Character.Taxi, "Start");
    }

    public void TransportPlayer(int id)
    {
        Locations targetLocation = (Locations) id;
        LoadingManager.LoadLevel(targetLocation.ToString());
        TimeManager.Instance.ReduceTime(360);
    }
}
