using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsCanvasScript : MonoBehaviour
{
    public GameObject canvas;

    public void openCanvas()
    {
        canvas.SetActive(true);
    }

    public void closeCanvas()
    {
        canvas.SetActive(false);
    }
}
