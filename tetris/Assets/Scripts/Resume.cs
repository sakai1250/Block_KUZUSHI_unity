using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Resume : MonoBehaviour
{
    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void LoadStage()
    {
        SceneManager.LoadScene(PreviousScene.previousScene);
        // SceneManager.LoadScene("Stage1");
        Debug.Log(PreviousScene.previousScene);
    }
}
