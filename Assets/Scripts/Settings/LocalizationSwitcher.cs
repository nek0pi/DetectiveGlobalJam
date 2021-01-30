using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationSwitcher : MonoBehaviour
{
    public void SwitchLanguage(int index)
    {
        switch (index)
        {
            case 0:
                LocalizationManager.ChangeLanguage(Language.English);
                break;
            case 1:
                LocalizationManager.ChangeLanguage(Language.Russian);
                break;
        }
    }
}
