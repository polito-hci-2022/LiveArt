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
        mancini = PlayerPrefs.GetInt("Mancini", 0);

        if (mancini == 1)
        {
            PlayerPrefs.SetInt("Mancini", 0);
            attivaMancini();
        }
        if (mancini == 0)
        {
            PlayerPrefs.SetInt("Mancini", 1);
            disattivaMancini();
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
