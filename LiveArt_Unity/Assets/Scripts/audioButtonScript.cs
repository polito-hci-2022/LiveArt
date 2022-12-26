using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class audioButtonScript : MonoBehaviour
{
    public GameObject textObject;

    TextMeshPro textmeshPro;

    // Start is called before the first frame update
    void Start()
    {
        //TextMeshPro textmeshPro =  textObject.gameObject.GetComponent<TextMeshPro>();

        //Debug.Log("Start");
        //Debug.Log (textObject);
        //Debug.Log (textmeshPro);

        int audio = PlayerPrefs.GetInt("Audio", 1);

        PlayerPrefs.SetInt("Audio", audio);
        PlayerPrefs.Save();
        setText (audio);
    }

    public void toggleAudio()
    {
        int audio = PlayerPrefs.GetInt("Audio", 0);
        if (audio == 0)
            PlayerPrefs.SetInt("Audio", 1);
        else if (audio == 1) PlayerPrefs.SetInt("Audio", 0);
        PlayerPrefs.Save();

        setText (audio);
    }

    void setText(int value)
    {
        Debug.Log (value);

        if(value == 1)
        textObject.SetActive(true);
        else if(value == 0)
        textObject.SetActive(false);

        //textmeshPro.SetText("Toggle Audio" + value);
    }
}
