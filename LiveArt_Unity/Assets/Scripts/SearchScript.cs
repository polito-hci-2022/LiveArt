using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchScript : MonoBehaviour
{
    public GameObject ContentHolder;

    public GameObject ErrorSearchMessage;

    public GameObject[] Element;

    public InputField SearchBar;

    public int totalElements;

    // Start is called before the first frame update
    void Start()
    {
        totalElements = ContentHolder.transform.childCount;

        Element = new GameObject[totalElements];

        for (int i = 0; i < totalElements; i++)
            Element[i] = ContentHolder.transform.GetChild(i).gameObject;
        
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
                if (ele.transform.GetChild(0).GetComponent<TMP_Text>().text.Length >= searchLength)
                {
                    if (SearchText.ToLower() ==  ele.transform.GetChild(0).GetComponent<TMP_Text>().text.Substring(0, searchLength).ToLower())
                        activElements += 1;
                    else
                        ele.SetActive(false);
                }
            }

            if (activElements == 0)
            {
                ErrorSearchMessage.SetActive(true);
                //disabilità interagibilità della main canvas
                //la ricerca non è andata a buon fine quindi risetto tutto ad active
                foreach (GameObject ele in Element)
                {
                    ele.SetActive(true);
                }
            }
        }
    }
}
