using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject CreditsCanvas;

    public GameObject SettingsCanvas;

    public GameObject SuggestCanvas;

    public void openCredits()
    {
        CreditsCanvas.SetActive(true);
    }

    public void closeCredits()
    {
        CreditsCanvas.SetActive(false);
    }

    public void openSettings()
    {
        SettingsCanvas.SetActive(true);
    }

    public void closeSettings()
    {
        SettingsCanvas.SetActive(false);
    }

    public void openSuggest()
    {
        SuggestCanvas.SetActive(true);
    }

    public void closeSuggest()
    {
        SuggestCanvas.SetActive(false);
    }
}
