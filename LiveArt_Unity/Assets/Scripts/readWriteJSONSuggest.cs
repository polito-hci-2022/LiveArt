using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readWriteJSONSuggest : MonoBehaviour
{
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

    public void test()
    {
        saveData("provaTitolo", "provaAutore", "provaDescrizione");
    }

    void saveData(string title, string author, string description)
    {
        SuggestedWork work = new SuggestedWork(title, author, description);
        string json = JsonUtility.ToJson(work);

        Debug.Log(json);

        SuggestedWork savedWork = JsonUtility.FromJson<SuggestedWork>(json);
        savedWork.print();
    }
}
