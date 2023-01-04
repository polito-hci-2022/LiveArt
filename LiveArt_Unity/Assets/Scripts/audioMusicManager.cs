using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMusicManager : MonoBehaviour
{
    public AudioSource mySource;

    private int music;

    void Awake()
    {
        music = PlayerPrefs.GetInt("Music", 1);
        SetStatus (music);
    }

    public void toggleMusic()
    {
        music = PlayerPrefs.GetInt("Music");
        if (music == 1)
        {
            PlayerPrefs.SetInt("Music", 0);
            SetStatus(0);
        }
        else if (music == 0)
        {
            PlayerPrefs.SetInt("Music", 1);
            SetStatus(1);
        }
    }

    void SetStatus(int status)
    {
        if (status == 1)
            mySource.Play();
        else
            mySource.Stop();
    }
}
