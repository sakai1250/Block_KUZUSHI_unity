using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Stage : MonoBehaviour
{
    private Button testButton;

    public void LoadStage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void LoadStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void LoadStage3()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void LoadStage4()
    {
        SceneManager.LoadScene("Stage4");
    }

    public void LoadStage5()
    {
        SceneManager.LoadScene("Stage5");
    }
}
