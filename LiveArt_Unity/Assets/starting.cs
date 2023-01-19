using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starting : MonoBehaviour
{
    public GameObject XRRIG;

    // Start is called before the first frame update
    void Start()
    {
        XRRIG.transform.rotation = Quaternion.Euler(0, 0, 0);
        Debug.Log(
            XRRIG.transform.rotation.x
                + " "
                + XRRIG.transform.rotation.y
                + " "
                + XRRIG.transform.rotation.z
        );
    }
}
