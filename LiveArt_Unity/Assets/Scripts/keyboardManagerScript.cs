using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class showKeyboard : MonoBehaviour
{
    public InputField searchField;
    public InputField titleField;
    public InputField authorField;
    public InputField descriptionField;

    public TMP_Text keyboardField;

    public GameObject keyboard;

    string mode;

    private IEnumerator coroutine;
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
        Debug.Log("open " + mode);
        if (keyboard.activeSelf == false) 
            keyboard.SetActive(true);
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

        
        keyboardField.SetText(actualText);

        coroutine = WaitAndPrint();

        StartCoroutine (coroutine);

    }

    private IEnumerator WaitAndPrint()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            keyboardField.SetText (actualText);
            yield return new WaitForSeconds(1.0f);
            keyboardField.SetText(actualText + "|");
        }
    }

    public void hide()
    {
        Debug.Log("close " + mode);
        Debug.Log("written text: " + keyboardField.text);
        if (keyboard.activeSelf == true)
        {
            switch (mode)
            {
                case "search":
                    searchField.SetText(keyboardField.text);
                    Debug
                        .Log("Test setted in searchfield: " + searchField.text);
                    break;
                case "title":
                    titleField.SetText(keyboardField.text);
                    Debug
                        .Log("Test setted in titleField: " + titleField.text);

                    break;
                case "author":
                    authorField.SetText(keyboardField.text);
                    Debug
                        .Log("Test setted in authorField: " + authorField.text);

                    break;
                case "description":
                    descriptionField.SetText(keyboardField.text);
                    Debug
                        .Log("Test setted in descriptionField: " + descriptionField.text);

                    break;
            }
            keyboardField.SetText("");
            keyboard.SetActive(false);
        }
    }
}

   
    public void AppendChar(string value)
    {
        StopCoroutine (coroutine);
        value = value.ToUpper();

        //Debug.Log("value= " + value + " pos= " + pos);
        actualText = actualText.Insert(pos, value);
        length++;
        pos++;
        keyboardField.SetText (actualText);
        StartCoroutine (coroutine);
    }

    public void Back()
    {
        if (length > 0)
        {
            StopCoroutine (coroutine);
            pos--;
            actualText = actualText.Remove(pos);
            textmeshPro.SetText (actualText);
            StartCoroutine (coroutine);
        }
    }

    

    public void Enter()
    {
        StopCoroutine (coroutine);
        actualText = "";
        pos = 0;
        length = 0;
    }
}

