using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalitaMancini : MonoBehaviour
{
    int mancini;

    public GameObject leftHandRay;

    public GameObject rightHandRay;

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
    }

    public void disattivaMancini()
    {
        PlayerPrefs.SetInt("Mancini", 0);
        leftHandRay.SetActive(false);
        rightHandRay.SetActive(true);
    }
}
