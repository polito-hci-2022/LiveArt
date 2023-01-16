using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageMenu : MonoBehaviour
{

    public float waitTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndPrint(waitTime));
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        this.gameObject.SetActive(false);
    }
}
