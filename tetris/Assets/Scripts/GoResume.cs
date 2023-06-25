using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class PreviousScene
{
    public static string previousScene = SceneManager.GetActiveScene().name;
}


public class GoResume : MonoBehaviour
{
    private bool goResume = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            goResume = true;
            PreviousScene.previousScene = SceneManager.GetActiveScene().name;
        }
        
    }
    
    private void FixedUpdate()
    {
        if (goResume)
        {
            goResume = false;
            SceneManager.LoadScene("Resume");
        }
    }
}
