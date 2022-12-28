using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leftHandToggle : MonoBehaviour
{
    int mancini;

    Toggle myToggle;

    // Start is called before the first frame update
    void Start()
    {
        myToggle = GetComponent<Toggle>();

        mancini = PlayerPrefs.GetInt("Mancini", 0);
        if (mancini == 1)
            myToggle.isOn = true;
        else if (mancini == 0) myToggle.isOn = false;
    }
}
