using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class informationCanvasManager : MonoBehaviour
{

    public GameObject informationCanvas;
    public GameObject interpretationCanvas;

    // Start is called before the first frame update
    void Start()
    {
        GoToInformations();
    }

    public void GoToInterpretations(){
        informationCanvas.SetActive(false);
        interpretationCanvas.SetActive(true);
    }

    public void GoToInformations(){
         informationCanvas.SetActive(true);
        interpretationCanvas.SetActive(false);
    }
    

}
