using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject CreditsCanvas;

    public GameObject SettingsCanvas;

    public GameObject SuggestCanvas;

    /* private bool creditsValue = false;

    private bool settingsValue = false;

    private bool suggestValue = false; */
    public void toggleCredits()
    {
        CreditsCanvas.SetActive(!CreditsCanvas.activeSelf);
        //creditsValue = !creditsValue;
    }

    public void toggleSettings()
    {
        SettingsCanvas.SetActive(!SettingsCanvas.activeSelf);
        //settingsValue = !settingsValue;
    }

    public void toggleSuggest()
    {
        SuggestCanvas.SetActive(!SuggestCanvas.activeSelf);
        //suggestValue = !suggestValue;
    }
}
