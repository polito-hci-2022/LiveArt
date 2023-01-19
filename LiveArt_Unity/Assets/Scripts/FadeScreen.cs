using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScreen : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2;
    public Color fadeColor;
    private Renderer rend;
    public GameObject XRRIG;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        if (fadeOnStart)
            FadeIn();
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("transitionToMenu", 0) == 1)
        {
            XRRIG.transform.rotation = Quaternion.Euler(0, -player.transform.localEulerAngles.y, 0);
            PlayerPrefs.SetInt("transitionToMenu", 0);
            PlayerPrefs.Save();
        }
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public void FadeIn()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            PlayerPrefs.SetInt("transitionToMenu", 1);
            PlayerPrefs.Save();
        }
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);
            rend.material.SetColor("_Color", newColor);
            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_Color", newColor2);
    }
}
