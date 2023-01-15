using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class saveRecord : MonoBehaviour
{
    public GameObject prefabContent;
    public GameObject parent;
    int posY = -30;

    bool test = true;
    string path;

    public InputField TitleInput;
    public InputField AuthorInput;
    public InputField DescripitonInput;

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
        if (test)
            path = @"C:\Users\edoar\code\LiveArt\LiveArt_Unity\Assets\DATA.txt";
        else
            path = "";
        readData();
    }

    public void AggiungiWoA()
    {
        InstaziaNuovoRecord(TitleInput.text, AuthorInput.text, DescripitonInput.text, true);
        writeData(TitleInput.text, AuthorInput.text, DescripitonInput.text);
        TitleInput.text = "";
        AuthorInput.text = "";
        DescripitonInput.text = "";
        thankText.SetActive(true);
    }

    void InstaziaNuovoRecord(string title, string author, string description, bool flag)
    {
        GameObject element = (GameObject)Instantiate(prefabContent);
        element.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().SetText(title);
        element.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().SetText(author);
        element.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().SetText(description);
        element.transform.SetParent(parent.transform);
        element.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        element.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
        if (flag)
            element.GetComponent<RectTransform>().localPosition = new Vector3(170, posY, 0);
        else
            element.GetComponent<RectTransform>().localPosition = new Vector3(170, posY, 0);
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
