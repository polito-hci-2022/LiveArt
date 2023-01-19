using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
using UnityEngine.Windows.Speech;
#endif
public class keyboardManagerScript : MonoBehaviour
{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
    private DictationRecognizer myRecognizer;
#endif
    public InputField searchField;

    public InputField titleField;

    public InputField authorField;

    public InputField descriptionField;

    public GameObject keyboard;

    public GameObject errorMic;

    public SearchScript searchScript;

    public Button buttonMic;

    public Color pressedColor;

    public Color notPressedColor;

    public AudioSource startingSound;
    public AudioSource endingSound;

    string mode;

    private string actualText;

    private int pos;

    private int length;

    bool dettatura = false;

    void Start()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN

        myRecognizer = new DictationRecognizer();

        myRecognizer.AutoSilenceTimeoutSeconds = 5;
        myRecognizer.InitialSilenceTimeoutSeconds = 5;

        myRecognizer.DictationError += (error, hresult) =>
        {
            Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
        };
        myRecognizer.DictationHypothesis += (text) =>
        {
            Debug.Log("Risultato: " + text);
            actualText = text.ToUpper();
            length = text.Length;
            pos = text.Length;
            setText();
        };

        myRecognizer.DictationComplete += (completionCause) =>
        {
            endingSound.Play();
            Debug.Log("Dettatura completata: " + completionCause);
            dettatura = false;
            ColorBlock cbNotPressed = buttonMic.colors;
            cbNotPressed.normalColor = notPressedColor;
            cbNotPressed.selectedColor = notPressedColor;
            buttonMic.colors = cbNotPressed;
        };
#endif
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
#if UNITY_EDITOR || UNITY_STANDALONE_WIN

        if (dettatura)
        {
            dettatura = false;
            myRecognizer.Stop();
        }
#endif

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
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        Debug.Log("Dettatura attiva");
        if (dettatura == false)
        {
            Debug.Log("Dettatura iniziata");
            startingSound.Play();
            ColorBlock cbPressed = buttonMic.colors;
            cbPressed.normalColor = pressedColor;
            cbPressed.selectedColor = pressedColor;
            buttonMic.colors = cbPressed;
            myRecognizer.Start();
            dettatura = true;
        }
        else
        {
            myRecognizer.Stop();
        }
#endif
#if UNITY_ANDROID
        Debug.Log("Dettatura non attiva");
        StartCoroutine(waitError());
#endif
    }

    IEnumerator waitError()
    {
        errorMic.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        errorMic.SetActive(false);
    }
}
