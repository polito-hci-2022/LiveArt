using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class newModalitaManciniView : MonoBehaviour
{
    private int mancini;

    public GameObject leftHandRay;
    public GameObject rightHandRay;

    public GameObject leftMenu;
    public GameObject rightMenu;

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

    void Update()
    {
        if (leftButton.action.WasPressedThisFrame())
        {
            attivaMancini();
        }
        if (rightButton.action.WasPressedThisFrame())
        {
            disattivaMancini();
        }
    }

    void attivaMancini()
    {
        PlayerPrefs.SetInt("Mancini", 1);
        if (PlayerPrefs.GetInt("menuOpen", 0) == 0)
        {
            leftMenu.SetActive(false);
            rightMenu.SetActive(true);
        }
        PlayerPrefs.Save();
        leftHandRay.SetActive(true);
        rightHandRay.SetActive(false);
    }

    void disattivaMancini()
    {
        PlayerPrefs.SetInt("Mancini", 0);
        if (PlayerPrefs.GetInt("menuOpen", 0) == 0)
        {
            leftMenu.SetActive(true);
            rightMenu.SetActive(false);
        }
        PlayerPrefs.Save();
        leftHandRay.SetActive(false);
        rightHandRay.SetActive(true);
    }
}
