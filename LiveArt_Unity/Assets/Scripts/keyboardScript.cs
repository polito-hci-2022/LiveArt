using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class keyboardScript : MonoBehaviour
{
    public TMP_Text textmeshPro;

    private IEnumerator coroutine;

    private string actualText = "";

    private int pos = 0;

    private int length = 0;

    void Awake()
    {
        //textmeshPro.SetText (actualText);
        coroutine = WaitAndPrint();
        StartCoroutine (coroutine);
    }

    public void AppendChar(string value)
    {
        value = value.ToUpper();
        Debug.Log("value= " + value + " pos= " + pos);
        actualText = actualText.Insert(pos, value);
        length++;
        pos++;
        //textmeshPro.SetText (actualText);
    }

    public void Enter()
    {
    }

    public void Back()
    {
        if (length > 0)
        {
            pos--;
            actualText = actualText.Remove(pos);
            //textmeshPro.SetText (actualText);
        }
    }

    private IEnumerator WaitAndPrint()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            textmeshPro.SetText (actualText);
            yield return new WaitForSeconds(1.0f);
            textmeshPro.SetText (actualText+"|");
        }
    }
}
