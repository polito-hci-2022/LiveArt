using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeMessage : MonoBehaviour
{

    public GameObject message;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.activeSelf == true)
            message.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
