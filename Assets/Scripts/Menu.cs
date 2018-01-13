using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	
	void Start () {
		
	}
	
	
	void Update () {
		
	}

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }
}
