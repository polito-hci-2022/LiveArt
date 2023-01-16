using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class keyboardManagerScript : MonoBehaviour
{
    private DictationRecognizer myRecognizer;

    public InputField searchField;

    public InputField titleField;

    public InputField authorField;

    public InputField descriptionField;

    public GameObject keyboard;

    public Button buttonMic;

    public Color pressedColor;

    public Color notPressedColor;

    string mode;

    private string actualText;

    private int pos;

    private int length;

    bool dettatura = false;

    void Start()
    {
        myRecognizer = new DictationRecognizer();

        myRecognizer.DictationHypothesis += (text) =>
        {
            actualText = text.ToUpper();
            length = text.Length;
            pos = text.Length;
            setText();
        };

        myRecognizer.DictationComplete += (completionCause) =>
        {
            Debug.Log("Dettatura completata: " + completionCause);
            dettatura = false;
            ColorBlock cbNotPressed = buttonMic.colors;
            cbNotPressed.normalColor = notPressedColor;
            buttonMic.colors = cbNotPressed;
        };
    }

    void setText()
    {
        switch (mode)
        {
            case "search":
                searchField.text = actualText;
                break;
            case "title":
                titleField.text = actualText;
                break;
            case "author":
                authorField.text = actualText;
                break;
            case "description":
                descriptionField.text = actualText;
                break;
        }
    }

    public void show(string givenMode)
    {

        if(dettatura){
            dettatura = false;
            myRecognizer.Stop();
        }

        mode = givenMode;
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
        setText();
    }

    public void Back()
    {
        if (length > 0)
        {
            pos--;
            length--;
            actualText = actualText.Remove(pos);
            setText();
        }
    }

    public void Clear()
    {
        actualText = "";
        setText();
        pos = 0;
        length = 0;
    }

    public void Dettatura()
    {
        if (dettatura == false)
        {
            ColorBlock cbPressed = buttonMic.colors;
            cbPressed.normalColor = pressedColor;
            cbPressed.selectedColor = pressedColor;
            buttonMic.colors = cbPressed;
            dettatura = true;
            myRecognizer.Start();
        }
        else
        {
            dettatura = false;
            myRecognizer.Stop();
        }
    }
}
