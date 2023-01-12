using System;
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

    public InputField TitleInput;
    public InputField AuthorInput;
    public InputField DescripitonInput;

    public GameObject thankText;

    public void AggiungiWoA()
    {
        InstaziaNuovoRecord(TitleInput.text, AuthorInput.text, DescripitonInput.text);
        TitleInput.text = "";
        AuthorInput.text = "";
        DescripitonInput.text = "";
        thankText.SetActive(true);
    }

    void InstaziaNuovoRecord(string title, string author, string description)
    {
        GameObject element = (GameObject)Instantiate(prefabContent);
        element.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().SetText(title);
        element.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().SetText(author);
        element.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().SetText(description);
        element.transform.SetParent(parent.transform);
        element.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        element.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
        element.GetComponent<RectTransform>().localPosition = new Vector3(170, posY, 0);
        posY = posY - 45;

    }

}
