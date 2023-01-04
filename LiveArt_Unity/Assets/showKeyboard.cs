using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showKeyboard : MonoBehaviour
{

    public GameObject keyboard;

    public void show(){
        if(keyboard.activeSelf == false)
            keyboard.SetActive(true);
    }

    public void hide(){
        if(keyboard.activeSelf == true)
            keyboard.SetActive(false);
    }
}
