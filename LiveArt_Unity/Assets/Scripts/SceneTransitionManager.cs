using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

    public FadeScreen fadeScreen;

    public void GoToScene(int sceneIndex){
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    IEnumerator GoToSceneRoutine(int sceneIndex){
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        SceneManager.LoadScene(sceneIndex);
    }

    public void SetWoAIndex(int woaIndex){
        PlayerPrefs.SetInt("WOA", woaIndex);
        PlayerPrefs.Save();
    }

     public void SetRoom(string room){
        PlayerPrefs.SetString("modeRoom", room);
        PlayerPrefs.Save();
    }

}
