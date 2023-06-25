using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stage1 : MonoBehaviour
{
    private Button testButton;

    public void load_Stage1()
    {
        SceneManager.LoadScene("Stage1");
        Debug.Log ("クリックされた");
    }

	// Use this for initialization
	void Start () {
		testButton = GetComponent <Button>();
		testButton.onClick.AddListener (load_Stage1);
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
