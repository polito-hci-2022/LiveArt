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
        {
            Element[i] = ContentHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    public void Search()
    {
        string SearchText = SearchBar.text;
        Debug.Log("Searching "+ SearchText );
        int searchLength = SearchText.Length;

        int activElements = 0;

        foreach (GameObject ele in Element)
        {
            if (searchLength > 0)
            {
                if (
                    ele
                        .transform
                        .GetChild(0)
                        .GetComponent<TextMeshProUGUI>()
                        .text
                        .Length >=
                    searchLength
                )
                {
                    if (
                        SearchText.ToLower() ==
                        ele
                            .transform
                            .GetChild(0)
                            .GetComponent<TextMeshProUGUI>()
                            .text
                            .Substring(0, searchLength)
                    )
                    {
                        ele.SetActive(true);
                        activElements += 1;
                    }

                    ele.SetActive(false);
                }

                if (activElements == 0)
                {
                    ErrorSearchMessage.SetActive(true);
                    //disabilità interagibilità della main canvas
                }
            }
        }
    }
}
