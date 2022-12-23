using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCanvas : MonoBehaviour
{

    public  GameObject GameObject;

    private bool value=true;

    public void Enable(){
        GameObject.SetActive(value);
        value = !value;
    }
}
