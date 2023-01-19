using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchScript : MonoBehaviour
{
    public GameObject ContentHolder;
    public GameObject ErrorSearchMessage;
    GameObject[] Element;
    public InputField SearchBar;

    // Start is called before the first frame update
    void Start()
    {
        int totalElements = ContentHolder.transform.childCount;
        Element = new GameObject[totalElements];

        for (int i = 0; i < totalElements; i++)
            Element[i] = ContentHolder.transform.GetChild(i).gameObject;
    }

    // Update is called once per frame
    public void Search()
    {
        //Debug.Log("Search: " + SearchBar.text);
        int activElements = 0;

        if (SearchBar.text.Length > 0)
        {
            foreach (GameObject ele in Element)
            {
                if (
                    ele.transform
                        .GetChild(0)
                        .GetComponent<TMP_Text>()
                        .text.ToLower()
                        .Contains(SearchBar.text.ToLower())
                )
                {
                    activElements += 1;
                    ele.SetActive(true);
                }
                else
                    ele.SetActive(false);
            }
            if (activElements == 0)
                ErrorSearchMessage.SetActive(true);
            else
                ErrorSearchMessage.SetActive(false);
        }
        else
        {
            foreach (GameObject ele in Element)
                ele.SetActive(true);
            ErrorSearchMessage.SetActive(false);
        }
    }
}
