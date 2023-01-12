using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportScript : MonoBehaviour
{
    public FadeScreen fadeScreen;

    public GameObject player;

    bool transition = false;

    string mode;

    void Start()
    {
        mode = PlayerPrefs.GetString("modeRoom", "room1");
        Debug.Log("mode: " + mode);
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

    public void TeleportRoom2()
    {
        if (!transition && mode != "room2")
            StartCoroutine(TeleportTo(250, -22, 0, "room2"));
    }

    public void TeleportRoom3()
    {
        if (!transition && mode != "room3")
            StartCoroutine(TeleportTo(500, 0, 0, "room3"));
    }

    public void TeleportRoom4()
    {
        if (!transition && mode != "room4")
            StartCoroutine(TeleportTo(750, 0, 0, "room4"));
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
        transition = false;
    }
}
