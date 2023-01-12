using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchScript : MonoBehaviour
{
    public GameObject ContentHolder;

    public GameObject ErrorSearchMessage;

    GameObject[] Element;

    public InputField SearchBar;

    int totalElements;

    int temp;

    // Start is called before the first frame update
    void Start()
    {
        totalElements = ContentHolder.transform.childCount;

        Element = new GameObject[totalElements];

        for (int i = 0; i < totalElements; i++){
            Element[i] = ContentHolder.transform.GetChild(i).gameObject;
            if(Element[i].name == ErrorSearchMessage.name)
                Element[i].SetActive(false);
        }
    }

    // Update is called once per frame
    public void Search()
    {
        string SearchText = SearchBar.text;
        Debug.Log("Searching " + SearchText);
        int searchLength = SearchText.Length;

        int activElements = 0;

        if (searchLength > 0)
        {
            foreach (GameObject ele in Element)
            {
                //Debug.Log(ele.name);
                if (ele.transform.GetChild(0).GetComponent<TMP_Text>().text.Length >=searchLength && SearchText.ToLower() == ele.transform.GetChild(0).GetComponent<TMP_Text>().text.Substring(0, searchLength).ToLower())
                {
                    Debug.Log("compatibile: " + ele.name);
                    activElements += 1;
                }
                 else
                    ele.SetActive(false);
            }

            if (activElements == 0) ErrorSearchMessage.SetActive(true);
        }
        else 
            if(searchLength == 0)
        {
            activElements = 1;
            temp = 0;
            foreach (GameObject ele in Element)
            {
                if (ele.name != ErrorSearchMessage.name)
                {
                    ele.SetActive(true);
                    temp++;
                }
            }
            activElements = temp;
        }
    }
}
