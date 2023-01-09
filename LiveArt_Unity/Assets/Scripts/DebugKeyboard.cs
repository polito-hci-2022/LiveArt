using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DebugKeyboard : MonoBehaviour
{
    public TMP_Text textmeshPro;

    // Start is called before the first frame update
    public void activate()
    {
        textmeshPro.SetText("Activated");
    }

    public void deactivate()
    {
        textmeshPro.SetText("Deactivated");
    }
}
