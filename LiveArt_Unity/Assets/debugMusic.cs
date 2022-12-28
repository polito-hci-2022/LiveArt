using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class debugMusic : MonoBehaviour
{
    int music;
    TextMeshPro textmeshPro;
    // Start is called before the first frame update
    void Start()
    {
        
     textmeshPro = GetComponent<TextMeshPro>();
         music = PlayerPrefs.GetInt("Music");
    }

    // Update is called once per frame
    void Update()
    {
                 music = PlayerPrefs.GetInt("Music");

        textmeshPro.SetText("Music is {0}", music);
    }
}
