using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class newModalitaMancini : MonoBehaviour
{
    private int mancini;

    public GameObject leftHandRay;
    public GameObject rightHandRay;


    public InputActionProperty leftButton;
    public InputActionProperty rightButton;


    // Start is called before the first frame update
    void Start()
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

    void Update(){
        if (leftButton.action.WasPressedThisFrame()){
            attivaMancini();
        }
        if (rightButton.action.WasPressedThisFrame()){
            disattivaMancini();
        }
    }

    void attivaMancini()
    {
        PlayerPrefs.SetInt("Mancini", 1);
        PlayerPrefs.Save();
        leftHandRay.SetActive(true);
        rightHandRay.SetActive(false);
    }

    void disattivaMancini()
    {
        PlayerPrefs.SetInt("Mancini", 0);
        PlayerPrefs.Save();
        leftHandRay.SetActive(false);
        rightHandRay.SetActive(true);
    }
}
