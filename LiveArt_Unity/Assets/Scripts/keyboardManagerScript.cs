using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class keyboardManagerScript : MonoBehaviour
{
    public InputField searchField;

    public InputField titleField;

    public InputField authorField;

    public InputField descriptionField;

    public GameObject keyboard;

    string mode;

    private string actualText;

    private int pos;

    private int length;

    public void showForSearch()
    {
        show("search");
    }

    public void showForTitle()
    {
        show("title");
    }

    public void showForAuthor()
    {
        show("author");
    }

    public void showForDescription()
    {
        show("description");
    }

    void show(string givenMode)
    {
        mode = givenMode;
        if (keyboard.activeSelf == false) keyboard.SetActive(true);
        switch (mode)
        {
            case "search":
                actualText = searchField.text;
                break;
            case "title":
                actualText = titleField.text;
                break;
            case "author":
                actualText = authorField.text;
                break;
            case "description":
                actualText = descriptionField.text;
                break;
        }
        pos = actualText.Length;
        length = pos;
    }

    public void hide()
    {
        if (keyboard.activeSelf == true)
        {
            actualText = "";
            pos = 0;
            length = 0;
            keyboard.SetActive(false);
        }
    }

    public void AppendChar(string value)
    {
        value = value.ToUpper();
        actualText = actualText.Insert(pos, value);
        length++;
        pos++;
        switch (mode)
        {
            case "search":
                searchField.text = actualText;
                break;
            case "title":
                titleField.SetTextWithoutNotify (actualText);
                break;
            case "author":
                authorField.SetTextWithoutNotify (actualText);
                break;
            case "description":
                descriptionField.SetTextWithoutNotify (actualText);
                break;
        }

    }

    public void Back()
    {
        if (length > 0)
        {
            pos--;
            actualText = actualText.Remove(pos);
            switch (mode)
            {
                case "search":
                    searchField.text = actualText;
                    break;
                case "title":
                    titleField.SetTextWithoutNotify (actualText);
                    break;
                case "author":
                    authorField.SetTextWithoutNotify (actualText);
                    break;
                case "description":
                    descriptionField.SetTextWithoutNotify (actualText);
                    break;
            }
        }
    }
}
