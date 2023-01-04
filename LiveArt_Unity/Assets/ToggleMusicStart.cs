using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusicStart : MonoBehaviour
{
    Toggle myToggle;

    // Start is called before the first frame update
    void Start()
    {
        myToggle = GetComponent<Toggle>();
        int music = PlayerPrefs.GetInt("Music");
        if (music == 1)
            myToggle.SetIsOnWithoutNotify(true);
        else if (music == 0) myToggle.SetIsOnWithoutNotify(false);
    }
}
