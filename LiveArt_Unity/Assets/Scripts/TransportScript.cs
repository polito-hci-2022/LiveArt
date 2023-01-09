using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportScript : MonoBehaviour
{
    public FadeScreen fadeScreen;

    public GameObject player;

    public void TeleportRoom1()
    {
        StartCoroutine(TeleportTo(750, 0, 0));
    }

    public void TeleportRoom2()
    {
        StartCoroutine(TeleportTo(250, 0, 0));
    }

    public void TeleportRoom3()
    {
        StartCoroutine(TeleportTo(500, 0, 0));
    }

    public void TeleportRoom4()
    {
        StartCoroutine(TeleportTo(750, 0, 0));
    }

    IEnumerator TeleportTo(int x, int y, int z)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        player.transform.position = new Vector3(x, y, z);
        fadeScreen.FadeIn();
    }
}
