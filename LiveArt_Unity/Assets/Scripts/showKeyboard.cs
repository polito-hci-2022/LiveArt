using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class showKeyboard : MonoBehaviour
{
    public TMP_Text searchField;

    public TMP_Text titleField;

    public TMP_Text authorField;

    public TMP_Text descriptionField;

    public TMP_Text keyboardField;

    public GameObject keyboard;

    string mode = "";

    public void showForSearch()
    {
        mode = "search";
        show();
    }

    public void showForTitle()
    {
        mode = "title";
        show();
    }

    public void showForAuthor()
    {
        mode = "author";
        show();
    }

    public void showForDescription()
    {
        mode = "description";
        show();
    }

    void show()
    {
        Debug.Log("open " + mode);
        if (keyboard.activeSelf == false) keyboard.SetActive(true);
        switch (mode)
        {
            case "search":
                Debug.Log("Already inserted text: " + searchField.text);
                keyboardField.SetText(searchField.text);
                Debug.Log("Inserted text in keyField: " + keyboardField.text);

                break;
            case "title":
                keyboardField.SetText(titleField.text);
                break;
            case "author":
                keyboardField.SetText(authorField.text);
                break;
            case "description":
                keyboardField.SetText(descriptionField.text);
                break;
        }
    }

    public void hide()
    {
        Debug.Log("close " + mode);
        Debug.Log("mode: " + mode);
        if (keyboard.activeSelf == true)
        {
            switch (mode)
            {
                case "search":
                    Debug.Log("written text: " + keyboardField.text);
                    searchField.SetText(keyboardField.text);
                    Debug
                        .Log("Text setted in searchfield: " + searchField.text);
                    break;
                case "title":
                    Debug.Log("written text: " + keyboardField.text);
                    titleField.SetText(keyboardField.text);
                    Debug.Log("text setted in titleField: " + titleField.text);

                    break;
                case "author":
                    Debug.Log("written text: " + keyboardField.text);
                    authorField.SetText(keyboardField.text);
                    Debug
                        .Log("text setted in authorField: " + authorField.text);

                    break;
                case "description":
                    Debug.Log("written text: " + keyboardField.text);
                    descriptionField.SetText(keyboardField.text);
                    Debug
                        .Log("text setted in descriptionField: " +
                        descriptionField.text);

                    break;
            }
            keyboardField.SetText("");
            keyboard.SetActive(false);
        }
    }
}
