using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransportScript : MonoBehaviour
{
    public FadeScreen fadeScreen;

    public GameObject player;

    public Button button1R;
    public Button button2R;
    public Button button3R;
    public Button button4R;

    public Button button1L;
    public Button button2L;
    public Button button3L;
    public Button button4L;

    public Color pressedColor;
    public Color notPressedColor;

    bool transition = false;

    string mode;

    void Start()
    {
        mode = PlayerPrefs.GetString("modeRoom", "room1");
        Debug.Log("mode: " + mode);
        updateButtons();
    }

    public void TeleportRoom1()
    {
        if (!transition && mode != "room1")
            StartCoroutine(TeleportTo(0, 0, 0, "room1"));
    }

    public void TeleportRoom1_1()
    {
        if (!transition && mode != "room1_1")
            StartCoroutine(TeleportTo(0, 250, 0, "room1_1"));
    }

    public void TeleportRoom1_2()
    {
        if (!transition && mode != "room1_2")
            StartCoroutine(TeleportTo(0, 500, 0, "room1_2"));
    }

    public void TeleportRoom2()
    {
        if (!transition && mode != "room2")
            StartCoroutine(TeleportTo(250, -22, 0, "room2"));
    }

    public void TeleportRoom2_1()
    {
        if (!transition && mode != "room2_1")
            StartCoroutine(TeleportTo(250, 250, 0, "room2_1"));
    }

    public void TeleportRoom2_2()
    {
        if (!transition && mode != "room2_2")
            StartCoroutine(TeleportTo(250, 500, 0, "room2_2"));
    }

    public void TeleportRoom3()
    {
        if (!transition && mode != "room3")
            StartCoroutine(TeleportTo(500, 0, 0, "room3"));
    }

    public void TeleportRoom3_1()
    {
        if (!transition && mode != "room3_1")
            StartCoroutine(TeleportTo(750, 250, 0, "room3_1"));
    }

    public void TeleportRoom3_2()
    {
        if (!transition && mode != "room3_2")
            StartCoroutine(TeleportTo(750, 500, 0, "room3_2"));
    }

    public void TeleportRoom4()
    {
        if (!transition && mode != "room4")
            StartCoroutine(TeleportTo(750, 0, 0, "room4"));
    }

    public void TeleportRoom4_1()
    {
        if (!transition && mode != "room4_1")
            StartCoroutine(TeleportTo(750, 250, 0, "room4_1"));
    }

    IEnumerator TeleportTo(int x, int y, int z, string newMode)
    {
        transition = true;
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        player.transform.position = new Vector3(x, y, z);
        fadeScreen.FadeIn();
        mode = newMode;
        PlayerPrefs.SetString("modeRoom", mode);
        PlayerPrefs.Save();
        updateButtons();
        transition = false;
    }

    void updateButtons()
    {
        updateOneButton(button1R, "room1");
        updateOneButton(button1L, "room1");

        updateOneButton(button2R, "room2");
        updateOneButton(button2L, "room2");

        updateOneButton(button3R, "room3");
        updateOneButton(button3L, "room3");

        updateOneButton(button4R, "room4");
        updateOneButton(button4L, "room4");
    }

    void updateOneButton(Button button, string selectedMode)
    {
        if (mode == selectedMode)
        {
            ColorBlock cbPressed = button.colors;
            cbPressed.normalColor = pressedColor;
            cbPressed.selectedColor = pressedColor;
            button.colors = cbPressed;
        }
        else
        {
            ColorBlock cbNotPressed = button.colors;
            cbNotPressed.normalColor = notPressedColor;
            button.colors = cbNotPressed;
        }
    }
}
