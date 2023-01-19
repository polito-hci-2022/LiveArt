using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalitaManciniView : MonoBehaviour
{
    private int mancini;

    public GameObject leftHandRay;

    public GameObject rightHandRay;

    public GameObject leftMenu;

    public GameObject rightMenu;

    public Button buttonON;

    public Button buttonOFF;

    public Color pressedColor;

    public Color notPressedColor;

    public void Awake()
    {
        mancini = PlayerPrefs.GetInt("Mancini", 0);
        Debug.Log("Lefthandmode (Event system)= " + mancini);
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
        if (PlayerPrefs.GetInt("menuOpen", 0) == 0)
        {
            leftMenu.SetActive(false);
            rightMenu.SetActive(true);
        }

        ColorBlock cbPressed = buttonON.colors;
        cbPressed.normalColor = pressedColor;
        cbPressed.selectedColor = pressedColor;

        buttonON.colors = cbPressed;

        ColorBlock cbNotPressed = buttonOFF.colors;
        cbNotPressed.normalColor = notPressedColor;
        buttonOFF.colors = cbNotPressed;

        PlayerPrefs.Save();
    }

    public void disattivaMancini()
    {
        PlayerPrefs.SetInt("Mancini", 0);
        leftHandRay.SetActive(false);
        rightHandRay.SetActive(true);
        if (PlayerPrefs.GetInt("menuOpen", 0) == 0)
        {
            leftMenu.SetActive(true);
            rightMenu.SetActive(false);
        }
        ColorBlock cbPressed = buttonOFF.colors;
        cbPressed.normalColor = pressedColor;
        cbPressed.selectedColor = pressedColor;

        buttonOFF.colors = cbPressed;

        ColorBlock cbNotPressed = buttonON.colors;
        cbNotPressed.normalColor = notPressedColor;
        buttonON.colors = cbNotPressed;

        PlayerPrefs.Save();
    }
}
