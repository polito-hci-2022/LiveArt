using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioMusicManager : MonoBehaviour
{
    public AudioSource mySource;

    public Button buttonON;

    public Button buttonOFF;

    public Color pressedColor;

    public Color highlightedColor;

    public Color notPressedColor;

    private int music;

    void Awake()
    {
        music = PlayerPrefs.GetInt("Music", 1);

        if (music == 1)
            Play();
        else if (music == 0) Stop();
        PlayerPrefs.Save();
    }

    public void Play()
    {
        PlayerPrefs.SetInt("Music", 1);

        ColorBlock cbPressed = buttonON.colors;

        cbPressed.normalColor = pressedColor;
        cbPressed.selectedColor = pressedColor;
        cbPressed.highlightedColor  = pressedColor;

        buttonON.colors = cbPressed;


        ColorBlock cbNotPressed = buttonOFF.colors;
        cbNotPressed.normalColor = notPressedColor;
        cbNotPressed.highlightedColor = highlightedColor;
        cbNotPressed.selectedColor = notPressedColor;

        buttonOFF.colors = cbNotPressed;

        mySource.Play();
    }

    public void Stop()
    {
        PlayerPrefs.SetInt("Music", 0);

        ColorBlock cbPressed = buttonOFF.colors;

        cbPressed.normalColor = pressedColor;
        cbPressed.selectedColor = pressedColor;
        cbPressed.highlightedColor = pressedColor;

        buttonOFF.colors = cbPressed;

        ColorBlock cbNotPressed = buttonON.colors;
        cbNotPressed.normalColor = notPressedColor;
        cbNotPressed.highlightedColor = highlightedColor;
        cbNotPressed.selectedColor = notPressedColor;

        buttonON.colors = cbNotPressed;

        mySource.Stop();
    }
}
