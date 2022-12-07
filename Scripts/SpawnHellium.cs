using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SpawnHellium : MonoBehaviour
    {
        public GameObject hellium;
        public float rewpawnTime=2.0f;
        private Vector2 screenBounds;
        
        public float [] places =new float [] {3.9314f,1.71f,5.9f,-0.88f,-3.49f,3.81f};
        
        void Start()
        {
            
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width,Screen.height,Camera.main.transform.position.z));
            StartCoroutine(helliumWave());

        }
        private void spawnHellium(){
            GameObject h = Instantiate(hellium) as GameObject;
           
            int n=Random.Range(0,3);
            
            int j=Random.Range(0,3);
            
            
                h.transform.position = new Vector2(screenBounds.x*-2f , Random.Range(-screenBounds.y,screenBounds.y));
          
        
        }
        IEnumerator helliumWave(){
            while(true){
                yield return new WaitForSeconds(10f);
                spawnHellium();
            }


    }
    }
