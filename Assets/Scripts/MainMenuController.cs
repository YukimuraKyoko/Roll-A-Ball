using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        //Use Application.Quit()  if not running on Unity (windows program)
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
