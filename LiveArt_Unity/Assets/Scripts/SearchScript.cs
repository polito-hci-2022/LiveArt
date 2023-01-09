using UnityEngine;
using TMPro;
public class SearchScript : MonoBehaviour
{

public GameObject ContentHolder;
public GameObject[] Element;
public GameObject SearchBar;
public int totalElements;


    // Start is called before the first frame update
    void Start()
    {
        totalElements= ContentHolder.transform.childCount;

        Element= new GameObject[totalElements];


        for (int i=0;i<totalElements;i++){
            Element[i]= ContentHolder.transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
   public void Search()
    {
        string SearchText= SearchBar.GetComponent<TMP_InputField>().text;
        int searchLength= SearchText.Length;

        int searchedEl=0;
        foreach(GameObject ele in Element){
            searchedEl+=1;

            if(ele.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Length >=searchLength)
            {
                if (SearchText.ToLower()==ele.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text.Substring(0,searchLength))
            {
                ele.SetActive(true);
            }
            
                ele.SetActive(false);
            }

        }


    }
}
