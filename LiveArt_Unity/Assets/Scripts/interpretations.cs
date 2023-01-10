using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class interpretations : MonoBehaviour
{
    public GameObject ModernInt;
    public GameObject MacronInt;
    public GameObject SgarbiInt;
    public GameObject OlivaInt;

    // Start is called before the first frame update
    public void LoadModernInterpretation()
    {
        //SceneManager.HideScene("MacronInt");
        //hide other interpretations if active
        MacronInt.SetActive(false);
        SgarbiInt.SetActive(false);
        OlivaInt.SetActive(false);
        ModernInt.SetActive(true);
    }

    public void LoadMacronInterpretation()
    {
        //SceneManager.HideScene("ModernInt");
        ModernInt.SetActive(false);
        SgarbiInt.SetActive(false);
        OlivaInt.SetActive(false);
        MacronInt.SetActive(true);
    }

    public void LoadSgarbiInterpretation()
    {
        //SceneManager.HideScene("ModernInt");
        ModernInt.SetActive(false);
        MacronInt.SetActive(false);
        OlivaInt.SetActive(false);
        SgarbiInt.SetActive(true);
    }

    public void LoadOlivaInterpretation()
    {
        //SceneManager.HideScene("ModernInt");
        ModernInt.SetActive(false);
        MacronInt.SetActive(false);
        SgarbiInt.SetActive(false);
        OlivaInt.SetActive(true);
    }
}
