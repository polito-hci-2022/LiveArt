using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    public GameObject gameMenuObject;

    public InputActionProperty showButton;

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            gameMenuObject.SetActive(!gameMenuObject.activeSelf);
        }
    }

    public void CloseMenu(){
         gameMenuObject.SetActive(false);
    }

}
