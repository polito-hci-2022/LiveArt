using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class debugMusic : MonoBehaviour
{
    int music;
    TMP_Text textmeshPro;
    // Start is called before the first frame update
    void Start()
    {
        
     textmeshPro = GetComponent<TMP_Text>();
         music = PlayerPrefs.GetInt("Music");

         Debug.Log(music);
         Debug.Log(textmeshPro);
    }

    // Update is called once per frame
    void Update()
    {
                 music = PlayerPrefs.GetInt("Music");

        textmeshPro.SetText("Music is {0}", music);
    }
}
