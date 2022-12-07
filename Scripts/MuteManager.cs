using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MuteManager : MonoBehaviour
{
    private bool isMuted;
    public GameObject mt;
   
    // Start is called before the first frame update
    void Start()
    {
        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;
        if (isMuted)
            mt.SetActive(true);
        else
            mt.SetActive(false);
    }
    public void MutePressed()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
        if (isMuted)
            mt.SetActive(true);
        else
            mt.SetActive(false);
    }
}
