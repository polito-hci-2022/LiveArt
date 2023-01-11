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
        myRecognizer.DictationResult += (text, confidence) =>
        {
            //Debug.LogFormat("Dictation result: {0}", text);
        };
        myRecognizer.DictationHypothesis += (text) =>
        {
            /* actualText +=  text.ToUpper();
            length += text.Length;
            pos += text.Length; */
            actualText = text.ToUpper();
            length = text.Length;
            pos = text.Length;
            setText();
        };
        myRecognizer.DictationComplete += (completionCause) =>
        {
            if (completionCause != DictationCompletionCause.Complete)
                Debug
                    .LogErrorFormat("Dictation completed unsuccessfully: {0}.",
                    completionCause);

            ColorBlock cbNotPressed = buttonMic.colors;
            cbNotPressed.normalColor = notPressedColor;
            buttonMic.colors = cbNotPressed;
        };
        myRecognizer.DictationError += (error, hresult) =>
        {
            Debug
                .LogErrorFormat("Dictation error: {0}; HResult = {1}.",
                error,
                hresult);
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

    public void show(string givenMode)
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
        setText();
    }

    public void Back()
    {
        if (length > 0)
        {
            pos--;
            actualText = actualText.Remove(pos);
            setText();
        }
    }

    public void Dettatura()
    {
        if (dettatura == false)
        {
            ColorBlock cbPressed = buttonMic.colors;
            cbPressed.normalColor = pressedColor;
            cbPressed.selectedColor = pressedColor;
            buttonMic.colors = cbPressed;

            myRecognizer.Start();
        }
        else
        {
            ColorBlock cbNotPressed = buttonMic.colors;
            cbNotPressed.normalColor = notPressedColor;
            buttonMic.colors = cbNotPressed;

            myRecognizer.Stop();
        }
        dettatura = !dettatura;
    }
}
