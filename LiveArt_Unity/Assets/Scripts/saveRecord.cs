using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class saveRecord : MonoBehaviour
{
    public GameObject prefabContent;
    public GameObject parent;
    int posY = -30;

    string path;

    public TrackedDeviceGraphicRaycaster canvasInteraction;

    public InputField TitleInput;
    public InputField AuthorInput;
    public InputField DescripitonInput;

    public Text ErrorText;

    public GameObject popup;
    public GameObject thankText;
    string[] lines;

    [Serializable]
    public class WOA
    {
        public string title,
            author,
            description;

        public WOA(string nTitle, string nAuthor, string nDescription)
        {
            title = nTitle;
            author = nAuthor;
            description = nDescription;
        }

        public void print()
        {
            Debug.Log("Debug: " + title + " " + author + " " + description);
        }
    }

    void Start()
    {
        path = Application.persistentDataPath + "/DATA.txt";

        if (!File.Exists(path))
            File.WriteAllText(path, "");
        Debug.Log(Application.persistentDataPath);
        readData();
    }

    public void AggiungiWoA()
    {
        if (TitleInput.text.Trim() == "")
        {
            ErrorText.text = "Input invalid: Title empty";
            ErrorText.gameObject.SetActive(true);
            thankText.SetActive(false);
        }
        else if (AuthorInput.text.Trim() == "")
        {
            ErrorText.text = "Input invalid: Author empty";
            ErrorText.gameObject.SetActive(true);
            thankText.SetActive(false);
        }
        else if (DescripitonInput.text.Trim() == "")
        {
            ErrorText.text = "Input invalid: Description empty";
            ErrorText.gameObject.SetActive(true);
            thankText.SetActive(false);
        }
        else
        {
            canvasInteraction.enabled = false;
            popup.SetActive(true);
        }
    }

    public void Confirm()
    {
        Close();
        ErrorText.gameObject.SetActive(false);
        InstaziaNuovoRecord(TitleInput.text, AuthorInput.text, DescripitonInput.text, true);
        writeData(TitleInput.text, AuthorInput.text, DescripitonInput.text);
        TitleInput.text = "";
        AuthorInput.text = "";
        DescripitonInput.text = "";
        thankText.SetActive(true);
    }

    public void Close()
    {
        canvasInteraction.enabled = true;
        popup.SetActive(false);
    }

    void InstaziaNuovoRecord(string title, string author, string description, bool flag)
    {
        GameObject element = (GameObject)Instantiate(prefabContent);
        element.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().SetText(title);
        element.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().SetText(author);
        //element.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().SetText(description);
        element.transform.SetParent(parent.transform);
        element.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        element.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);

        element.GetComponent<RectTransform>().localPosition = new Vector3(170, posY, 0);
        element.GetComponent<infoSaving>().Set(author, title, description);

        posY = posY - 45;
    }

    void readData()
    {
        lines = System.IO.File.ReadAllLines(path);
        WOA woa;
        foreach (string str in lines)
        {
            woa = JsonUtility.FromJson<WOA>(str);
            InstaziaNuovoRecord(woa.title, woa.author, woa.description, false);
        }
    }

    async void writeData(string title, string author, string description)
    {
        using StreamWriter file = new(path, append: true);
        await file.WriteLineAsync(JsonUtility.ToJson(new WOA(title, author, description)));
    }
}
