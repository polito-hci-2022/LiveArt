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
        Debug.Log("Lefthandmode (Event system)= " + (mancini == 1));
        if (mancini == 1)
        {
            attivaMancini();
        }
        if (mancini == 0)
        {
            disattivaMancini();
        }
    }

    public void toggleMancini()
    {
        //mancini = PlayerPrefs.GetInt("Mancini", 0);
        if (mancini == 1)
        {
            Debug.Log("LeftHand: 1 -> 0");
            mancini = 0;
            PlayerPrefs.SetInt("Mancini", mancini);
            disattivaMancini();
        }
        if (mancini == 0)
        {
            Debug.Log("LeftHand: 0 -> 1");
            mancini = 1;
            PlayerPrefs.SetInt("Mancini", mancini);
            attivaMancini();
        }
    }

    void attivaMancini()
    {
        leftHandRay.SetActive(true);
        rightHandRay.SetActive(false);
    }

    void disattivaMancini()
    {
        leftHandRay.SetActive(false);
        rightHandRay.SetActive(true);
    }
}
