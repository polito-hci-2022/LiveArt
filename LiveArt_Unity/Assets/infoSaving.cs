using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class infoSaving : MonoBehaviour
{
    string author;
    string title;
    string description;

    public void Set(string authorNew, string titleNew, string descriptionNew)
    {
        author = authorNew;
        title = titleNew;
        description = descriptionNew;
    }

    public void Show()
    {
        PlayerPrefs.SetString("showTitle", title);
        PlayerPrefs.SetString("showAuthor", author);
        PlayerPrefs.SetString("showDescription", description);
        Debug.Log(title + " " + author + " " + description);
        PlayerPrefs.SetInt("showCanvas", 1);
        PlayerPrefs.Save();
    }
}
