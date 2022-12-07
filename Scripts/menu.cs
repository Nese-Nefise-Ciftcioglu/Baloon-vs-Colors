using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class menu : MonoBehaviour
{



    public Text highscoreText;
    public GameObject theManager;
    void Start(){
        highscoreText.text = ("Highscore: " + PlayerPrefs.GetFloat("Highscore"));
        MobileAds.Initialize(initStatus => { });

    }
    public void PlayGame(){
        //DontDestroyOnLoad(theManager);
        SceneManager.LoadScene(1);
        

    }
    public void QuitGame(){
        Application.Quit();
    }
}
