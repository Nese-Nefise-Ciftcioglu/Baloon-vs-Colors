using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;


public class invulnerable : MonoBehaviour
{
    public GameObject balloon;
    public GameObject backGround;
    GameObject restart;
    GameObject rewardedPanel;
    public Color bgLightColor;
    GameObject srk;
    SpriteRenderer spriteRenderer;
    public Color tempC;
    public GameObject Heart;
    bool isAdClosed = false;
    bool isRewarded = false;
    int counter = 0;
    public GameObject VidButton;
    private RewardBasedVideoAd rewardedAd;
    private string rewardedAdID = "ca-app-pub-6518685517845474/6608146892";

    private void Start()
    {
        rewardedAd = RewardBasedVideoAd.Instance;
        RequestRewardedAd();
        rewardedAd.OnAdLoaded += HandleRewardBasedVideoLoaded;
        rewardedAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        rewardedAd.OnAdRewarded += HandleRewardBasedVideoRewarded;
        rewardedAd.OnAdClosed += HandleRewardBasedVideoClosed;

    }


    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
       
    }
    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args) //internet yok video yüklenemedi
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
        VidButton.SetActive(false);
    }
    

    void Update()
    {
        if (isAdClosed)
        {
            if (isRewarded)
            {
                giveChance();
                Debug.Log("called");
                isRewarded = false;
                counter++;
                VidButton.SetActive(false);
            }
            else
            {
                // Ad closed but user skipped ads, so no reward 
                // Ad your action here 
            }
            isAdClosed = false;  // to make sure this action will happen only once.
        }
    }


    public void RequestRewardedAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(request, rewardedAdID);
    }
    public void ShowRewardedAd()
    {
        if (rewardedAd.IsLoaded())
        {
            if (counter == 0)
            {
                rewardedAd.Show();
            }
            else
            {
                Debug.Log("You already watched video");
            }
            
        }
        else
        {
            Debug.Log("Video not loaded");
        }
    }
    public void HandleRewardBasedVideoRewarded(object sender,Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
          "HandleRewardedAdRewarded event received for "
              + amount.ToString() + " " + type);
        isRewarded = true;
        Debug.Log("called");




    }
    public void HandleRewardBasedVideoClosed(object sender,EventArgs args)
    {
        Debug.Log("Rewarded video hasn't ben finished");
        RequestRewardedAd();
        isAdClosed = true;
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }
    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
      


    }

  



    public void giveChance()
    { 
        GameObject balInst = Instantiate(balloon, new Vector3(-11.69f, 3.77f, 0f), Quaternion.identity);
        
        srk = GameObject.FindWithTag("backGroundPrefab");
        spriteRenderer=srk.GetComponent<SpriteRenderer>();
        spriteRenderer.color = bgLightColor;
        restart = GameObject.FindWithTag("RestartScreen");
        restart.SetActive(false);
        MonoBehaviour camMono = Camera.main.GetComponent<MonoBehaviour>();
        
        camMono.StartCoroutine(GetInvulnerable(balInst));
        balInst.GetComponent<SpriteRenderer>().material.color = tempC;
        tempC.a = 1f;
       

    }
    IEnumerator GetInvulnerable(GameObject balInst)
    {

        balInst.GetComponent<SpriteRenderer>().material.color = tempC;
        tempC.a = 0.5f;

        Physics2D.IgnoreLayerCollision(8, 9, true);       
        yield return new WaitForSeconds(4f);
        balInst.GetComponent<SpriteRenderer>().material.color = tempC;
        tempC.a = 1f;
        Physics2D.IgnoreLayerCollision(8, 9, false);       
    }
}


