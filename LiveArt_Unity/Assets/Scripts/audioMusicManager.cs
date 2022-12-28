using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMusicManager : MonoBehaviour
{
    public AudioSource mySource;

    private int audio;

    private int music;

    // Start is called before the first frame update
    void Start()
    {
        music = PlayerPrefs.GetInt("Music", 1);
    }

    public void toggleMusic()
    {
        music = PlayerPrefs.GetInt("Music");
        if (music == 1)
        {
            PlayerPrefs.SetInt("Music", 0);
            SetStatus(false);
        }
        else if (music == 0)
        {
            PlayerPrefs.SetInt("Music", 1);
            SetStatus(true);
        }
    }

    void SetStatus(bool status)
    {
        if (status)
            mySource.Play();
        else
            mySource.Stop();
    }
}
