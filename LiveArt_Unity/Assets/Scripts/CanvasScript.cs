using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public GameObject MainCanvas;

    public GameObject CreditsCanvas;

    public GameObject SettingsCanvas;

    public GameObject SuggestCanvas;

    public void openCredits()
    {
        MainCanvas.SetActive(false);
        CreditsCanvas.SetActive(true);
    }

    public void closeCredits()
    {
        CreditsCanvas.SetActive(false);
        MainCanvas.SetActive(true);
    }

    public void openSettings()
    {
        MainCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
    }

    public void closeSettings()
    {
        SettingsCanvas.SetActive(false);
        MainCanvas.SetActive(true);
    }

    public void openSuggest()
    {
        MainCanvas.SetActive(false);
        SuggestCanvas.SetActive(true);
    }

    public void closeSuggest()
    {
        SuggestCanvas.SetActive(false);
        MainCanvas.SetActive(true);
    }
}
