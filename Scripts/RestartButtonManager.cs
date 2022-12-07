using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButtonManager : MonoBehaviour
{
    public GameObject reScreen;
    public Text highscoreText;
    public GameObject theManager;
    void Start(){
        PlayerPrefs.GetFloat("Highscore");
        highscoreText.text = ("Highscore: " + PlayerPrefs.GetFloat("Highscore"));

    }
    public void EndGame(){
        reScreen.SetActive(true);

    }
     public void returnMenu(){
        SceneManager.LoadScene(0);
       

    }
    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
