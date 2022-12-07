using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAd : MonoBehaviour
{

    public string gameId = "3950521";
    public string placementId = "BannerID";
   


    void Start()
    {
        Advertisement.Initialize(gameId);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_RIGHT);
        Advertisement.Banner.Show(placementId);
    }
}