using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{
    public GameObject MainCanvas;

    public GameObject CreditsCanvas;

    public GameObject SettingsCanvas;

    public GameObject SuggestCanvas;

    public GameObject thankText;

    public InputField searchField;

    public InputField titleField;

    public InputField authorField;

    public InputField descriptionField;

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
        searchField.text = "";
        SuggestCanvas.SetActive(true);
    }

    public void closeSuggest()
    {
        titleField.text = "";
        authorField.text = "";
        descriptionField.text = "";
        SuggestCanvas.SetActive(false);
        thankText.SetActive(false);
        MainCanvas.SetActive(true);
    }
}
