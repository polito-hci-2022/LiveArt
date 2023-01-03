using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyboardOculus : MonoBehaviour
{
    private TouchScreenKeyboard overlayKeyboard;

    InputField inputFieldCo;

    // Start is called before the first frame update
    void Start()
    {
        inputFieldCo = GetComponent<InputField>();
        Debug.Log(inputFieldCo.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (overlayKeyboard != null) inputFieldCo.text = overlayKeyboard.text;
    }

    public void ShowKeyboard()
    {
        overlayKeyboard = TouchScreenKeyboard.Open("dawdad", TouchScreenKeyboardType.Default);

    }

    public void HideKeyboard()
    {
    }
}
