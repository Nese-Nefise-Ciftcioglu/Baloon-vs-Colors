using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip hitWallSound,coinSound,deathSound,helliumSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        hitWallSound = Resources.Load<AudioClip>("Hit");
        coinSound = Resources.Load<AudioClip>("Coin");
        deathSound = Resources.Load<AudioClip>("Die");
        helliumSound = Resources.Load<AudioClip>("Hellium");

        audioSrc = GetComponent<AudioSource> ();
    
    }
    public static void PlaySound(string clip){
        switch(clip){
            case "Hit":
                audioSrc.PlayOneShot(hitWallSound);
                break;
             case "Coin":
                audioSrc.PlayOneShot(coinSound);
                break;
             case "Die":
                audioSrc.PlayOneShot(deathSound);
                break;
             case "Hellium":
                audioSrc.PlayOneShot(helliumSound);
                break;            

        }
    }

}
