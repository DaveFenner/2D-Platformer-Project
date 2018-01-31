using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip audioClip;

    public Button playBtn;
    public Button aboutBtn;
    public Button quitBtn;

    public Image logo;

    public GameObject aboutObjects;

    void Start () {
		
	}
	
	
	void Update () {
		
	}

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene("Main");
    }

    public void AboutBtn()
    {
        playBtn.gameObject.SetActive(false);
        aboutBtn.gameObject.SetActive(false);
        quitBtn.gameObject.SetActive(false);
        logo.gameObject.SetActive(false);
        aboutObjects.SetActive(true);
    }

    public void BackBtn()
    {
        aboutObjects.SetActive(false);
        playBtn.gameObject.SetActive(true);
        aboutBtn.gameObject.SetActive(true);
        quitBtn.gameObject.SetActive(true);
        logo.gameObject.SetActive(true);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

}
