using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leftHandToggle : MonoBehaviour
{
    int mancini;

    Toggle myToggle;

    // Start is called before the first frame update
    void Awake()
    {
        myToggle = GetComponent<Toggle>();

        mancini = PlayerPrefs.GetInt("Mancini", 0);

        Debug.Log("LeftHandMode = " + (mancini == 1));

        if (mancini == 1)
            myToggle.SetIsOnWithoutNotify(true);
        else if (mancini == 0) myToggle.SetIsOnWithoutNotify(false);
    }
}
