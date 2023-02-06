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

    public GameObject KeyboardCanvas;

    public GameObject thankText;
    public GameObject expanded;

    public InputField searchField;

    public InputField titleField;

    public InputField authorField;

    public InputField descriptionField;


    public Text titleText;
    public Text authorText;
    public Text descriptionText;

    void Awake()
    {
        CloseExpanded();
    }

    void Start(){
        MainCanvas.SetActive(true);
        CreditsCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        SuggestCanvas.SetActive(false);
        KeyboardCanvas.SetActive(false);
    }

    void Update()
    {
        int val = PlayerPrefs.GetInt("showCanvas");
        if (val == 1)
        {
            expanded.SetActive(true);
            titleText.text = "Title: " + PlayerPrefs.GetString("showTitle");
            authorText.text = "Author: " + PlayerPrefs.GetString("showAuthor");
            descriptionText.text = PlayerPrefs.GetString("showDescription");
        }
        else
            expanded.SetActive(false);
    }

    public void CloseExpanded()
    {
        PlayerPrefs.SetInt("showCanvas", 0);
        PlayerPrefs.Save();
    }

    public void openCredits()
    {
        MainCanvas.SetActive(false);
        KeyboardCanvas.SetActive(false);
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
        KeyboardCanvas.SetActive(false);
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
        KeyboardCanvas.SetActive(false);
        MainCanvas.SetActive(true);
    }
}
