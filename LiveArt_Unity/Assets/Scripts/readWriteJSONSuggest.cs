using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class readWriteJSONSuggest : MonoBehaviour
{
    public GameObject prefabContent;
    public GameObject parent;
    int posY = -30;

    public InputField TitleInput;
    public InputField AuthorInput;
    public InputField DescripitonInput;


    [Serializable]
    class SuggestedWork
    {
        private string title;

        private string author;

        private string description;

        public SuggestedWork(string title, string author, string description)
        {
            this.title = title;
            this.author = author;
            this.description = description;
        }

        public void print()
        {
            Debug.Log(title + " " + author + " " + description);
        }
    }

    void Start(){
       // InstaziaNuovoRecord("provaTitolo1", "provaAutore1", "provaDescrizione1");
        // InstaziaNuovoRecord("provaTitolo2", "provaAutore2", "provaDescrizione2");
    }

    public void AggiungiWoA(){
        InstaziaNuovoRecord(TitleInput.text, AuthorInput.text, DescripitonInput.text);
    }

    void InstaziaNuovoRecord(string title, string author, string description)
    {

        Debug.Log("Instantiate " + title + " " + author + " " +description);
        GameObject element = (GameObject)Instantiate(prefabContent);
       element.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().SetText(title);
        element.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().SetText(author);
        element.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().SetText(description);  
        element.transform.SetParent(parent.transform);
        element.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        element.GetComponent<RectTransform>().localRotation  = Quaternion.Euler(0,0,0);
        element.GetComponent<RectTransform>().localPosition  = new Vector3(0,posY,0);
        posY = posY -45;

        Debug.Log(element.GetComponent<RectTransform>().localPosition);
    }

    void saveData(string title, string author, string description)
    {
        SuggestedWork work = new SuggestedWork(title, author, description);
        string json = JsonUtility.ToJson(work);

        Debug.Log (json);

        SuggestedWork savedWork = JsonUtility.FromJson<SuggestedWork>(json);
        savedWork.print();
    }
}
