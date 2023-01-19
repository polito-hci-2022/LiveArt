using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interpretations : MonoBehaviour
{
    public GameObject intOne;
    public GameObject intTwo;
    public GameObject intThree;
    public Button button1;
    public Button button2;
    public Button button3;
    public Color pressedColor;
    public Color highlightedColor;

    public Color notPressedColor;

    void Start()
    {
        LoadInterpretationOne();
    }

    // Start is called before the first frame update
    public void LoadInterpretationOne()
    {
        intTwo.SetActive(false);
        intThree.SetActive(false);
        intOne.SetActive(true);

        ColorBlock cbPressed = button1.colors;
        cbPressed.normalColor = pressedColor;
        cbPressed.highlightedColor = pressedColor;
        cbPressed.selectedColor = pressedColor;
        button1.colors = cbPressed;

        ColorBlock cbNotPressed = button2.colors;
        cbNotPressed.normalColor = notPressedColor;
        cbNotPressed.selectedColor = notPressedColor;
        cbNotPressed.highlightedColor = highlightedColor;
        button2.colors = cbNotPressed;
        button3.colors = cbNotPressed;
    }

    public void LoadInterpretationTwo()
    {
        intOne.SetActive(false);
        intThree.SetActive(false);
        intTwo.SetActive(true);

        ColorBlock cbPressed = button2.colors;
        cbPressed.normalColor = pressedColor;
        cbPressed.highlightedColor = pressedColor;
        cbPressed.selectedColor = pressedColor;
        button2.colors = cbPressed;

        ColorBlock cbNotPressed = button2.colors;
        cbNotPressed.normalColor = notPressedColor;
        cbNotPressed.selectedColor = notPressedColor;
        cbNotPressed.highlightedColor = highlightedColor;
        button1.colors = cbNotPressed;
        button3.colors = cbNotPressed;
    }

    public void LoadInterpretationThree()
    {
        intOne.SetActive(false);
        intTwo.SetActive(false);
        intThree.SetActive(true);

        ColorBlock cbPressed = button3.colors;
        cbPressed.normalColor = pressedColor;
        cbPressed.highlightedColor = pressedColor;
        cbPressed.selectedColor = pressedColor;
        button3.colors = cbPressed;

        ColorBlock cbNotPressed = button2.colors;
        cbNotPressed.normalColor = notPressedColor;
        cbNotPressed.selectedColor = notPressedColor;
        cbNotPressed.highlightedColor = highlightedColor;
        button2.colors = cbNotPressed;
        button1.colors = cbNotPressed;
    }
}
