using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : Singleton<LocalizationManager>
{
    [SerializeField] GameObject leanLocalizationPrefab;
    [SerializeField] Language currentLanguage = Language.English;

    public void SpawnLocalizationTool()
    {
        Instantiate(leanLocalizationPrefab);
    }
    public static void ChangeLanguage(string languageName)
    {
        switch (languageName)
        {
            case "Russian":
                Lean.Localization.LeanLocalization.CurrentLanguage = languageName;
                LocalizationManager.Instance.currentLanguage = Language.Russian;
                //Add yarn localization
                break;
            case "English":
                Lean.Localization.LeanLocalization.CurrentLanguage = languageName;
                LocalizationManager.Instance.currentLanguage = Language.English;
                //Add yarn localization
                break;
        }
       
    }

    public static void ChangeLanguage(Language language)
    {
        switch (language)
        {
            case Language.Russian:
                Lean.Localization.LeanLocalization.CurrentLanguage = "Russian";
                LocalizationManager.Instance.currentLanguage = Language.Russian;
                //Add yarn localization
                break;
            case Language.English:
                Lean.Localization.LeanLocalization.CurrentLanguage = "English";
                LocalizationManager.Instance.currentLanguage = Language.English;
                //Add yarn localization
                break;
        }

    }


    public static string GetTranslation(string textName)
    {
        return Lean.Localization.LeanLocalization.GetTranslationText(textName);
    }
}
public enum Language
{ 
    Russian, English
}
