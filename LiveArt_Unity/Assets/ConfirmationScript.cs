using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationScript : MonoBehaviour
{
    public Text title;
    public Text author;
    public Text description;

    public InputField titleInput;
    public InputField authorInput;
    public InputField descriptionInput;

    public void Set()
    {
        string titleString = "Title: " + titleInput.text;
        if (titleString.Length > 25)
            titleString = titleString.Substring(0, 25) + ".";
        title.text = titleString;

        string authorString = "Author: " + authorInput.text;
        if (authorString.Length > 25)
            authorString = authorString.Substring(0, 25) + ".";
        author.text = authorString;

        string descriptionString = "Description: " + descriptionInput.text;
        if (descriptionString.Length > 79)
            descriptionString = descriptionString.Substring(0, 79) + ".";
        description.text = descriptionString;
    }

    public void Reset()
    {
        title.text = "";
        author.text = "";
        description.text = "";
    }
}
