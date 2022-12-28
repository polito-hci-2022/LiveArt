using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicButtonScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
      
        int audio = PlayerPrefs.GetInt("Music", 0);

        PlayerPrefs.SetInt("Music", audio);
        PlayerPrefs.Save();
    }

    public void toggleMusic()
    {
        int music = PlayerPrefs.GetInt("Music", 0);
        if (music == 0)
            PlayerPrefs.SetInt("Music", 1);
        else if (music == 1) PlayerPrefs.SetInt("Music", 0);
        PlayerPrefs.Save();

    }
}
