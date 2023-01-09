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
        if (music == 1)
            Play();
        else if (music == 0) Stop();
    }

    public void Play()
    {
        PlayerPrefs.SetInt("Music", 1);
        mySource.Play();
    }

    public void Stop()
    {
        PlayerPrefs.SetInt("Music", 0);
        mySource.Stop();
    }
}
