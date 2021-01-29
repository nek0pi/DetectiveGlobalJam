using Lean.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationManager : Singleton<LocalizationManager>
{
    [SerializeField] GameObject leanLocalizationPrefab;

    public void Start()
    {
        SpawnLocalizationTool();
    }
    public void SpawnLocalizationTool()
    {
        Instantiate(leanLocalizationPrefab);
    }
    public static void ChangeLanguage(string languageName)
    {
        Lean.Localization.LeanLocalization.CurrentLanguage = languageName;
    }
}
