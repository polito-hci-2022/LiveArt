using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugMancini : MonoBehaviour
{
    int mancini;

    TMP_Text textmeshPro;

    // Start is called before the first frame update
    void Start()
    {
        textmeshPro = GetComponent<TMP_Text>();
        mancini = PlayerPrefs.GetInt("Mancini");

        Debug.Log (mancini);
    }

    // Update is called once per frame
    void Update()
    {
        mancini = PlayerPrefs.GetInt("Mancini");

        textmeshPro.SetText("Mancini is {0}", mancini);
    }
}
