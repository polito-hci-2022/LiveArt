using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject CreditsCanvas;

    public GameObject SettingsCanvas;

    public GameObject SuggestCanvas;

    private bool creditsValue = false;

    private bool settingsValue = false;

    private bool suggestValue = false;

    public void toggleCredits()
    {
        CreditsCanvas.SetActive (creditsValue);
        creditsValue = !creditsValue;
    }

    public void toggleSettings()
    {
        SettingsCanvas.SetActive (settingsValue);
        settingsValue = !settingsValue;
    }

    public void toggleSuggest()
    {
        SuggestCanvas.SetActive (suggestValue);
        suggestValue = !suggestValue;
    }
}
