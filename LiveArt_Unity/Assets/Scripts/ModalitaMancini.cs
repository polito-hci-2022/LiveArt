using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalitaMancini : MonoBehaviour
{
    private int mancini;

    public GameObject leftHandRay;

    public GameObject rightHandRay;

    public Button buttonON;

    public Button buttonOFF;

    public Color pressedColor;
    public Color highlightedColor;
    public Color notPressedColor;

    public void Awake()
    {
        mancini = PlayerPrefs.GetInt("Mancini", 0);
        if (mancini == 1)
        {
            attivaMancini();
        }
        else if (mancini == 0)
        {
            disattivaMancini();
        }
    }

    public void attivaMancini()
    {
        PlayerPrefs.SetInt("Mancini", 1);
        leftHandRay.SetActive(true);
        rightHandRay.SetActive(false);

        ColorBlock cbPressed = buttonON.colors;
        cbPressed.normalColor = pressedColor;
        cbPressed.selectedColor = pressedColor;
        cbPressed.highlightedColor  = pressedColor;

        buttonON.colors = cbPressed;

        ColorBlock cbNotPressed = buttonOFF.colors;
        cbNotPressed.normalColor = notPressedColor;
        cbNotPressed.selectedColor = notPressedColor;
        cbNotPressed.highlightedColor = highlightedColor;
        buttonOFF.colors = cbNotPressed;

        PlayerPrefs.Save();
    }

    public void disattivaMancini()
    {
        PlayerPrefs.SetInt("Mancini", 0);
        leftHandRay.SetActive(false);
        rightHandRay.SetActive(true);

        ColorBlock cbPressed = buttonOFF.colors;
        cbPressed.normalColor = pressedColor;
        cbPressed.selectedColor = pressedColor;
        cbPressed.highlightedColor  = pressedColor;

        buttonOFF.colors = cbPressed;

        ColorBlock cbNotPressed = buttonON.colors;
        cbNotPressed.normalColor = notPressedColor;
        cbNotPressed.selectedColor = notPressedColor;
        cbNotPressed.highlightedColor = highlightedColor;
        buttonON.colors = cbNotPressed;

        PlayerPrefs.Save();
    }
}
