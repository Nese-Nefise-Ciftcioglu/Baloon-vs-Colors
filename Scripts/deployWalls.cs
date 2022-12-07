using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class deployWalls : MonoBehaviour
    {
        public GameObject blue;
        public GameObject yellow;
        public GameObject red;
        public float rewpawnTime=2.0f;
        private Vector2 screenBounds;
        public GameObject littleBlack1;
        public GameObject littleBlack2;

        
        public float [] places =new float [] {5.593f,0.39f,-4.82f};
        

        // Start is called before the first frame update
        void Start()
        {
            
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width,Screen.height,Camera.main.transform.position.z));
            StartCoroutine(wallWave());
        

        }
        private void spawnWall(){
            GameObject b = Instantiate(blue) as GameObject;
            GameObject y = Instantiate(yellow) as GameObject;
            GameObject r = Instantiate(red) as GameObject;
            GameObject lb1 = Instantiate(littleBlack1) as GameObject;
            GameObject lb2 = Instantiate(littleBlack2) as GameObject;
       

            int n=Random.Range(0,3);
            b.transform.position = new Vector2(screenBounds.x*-2.7f , places[n]);
            int j=Random.Range(0,3);
            while(j==n){
                j=Random.Range(0,3);
            }
            if(j!=n){
                y.transform.position = new Vector2(screenBounds.x*-2.7f , places[j]);
            }
            int k=Random.Range(0,3);
            while(k==j || k==n){
                k=Random.Range(0,3);
            }
            if(k!=j && k!=n){
                r.transform.position = new Vector2(screenBounds.x *-2.7f, places[k]);
            }
            lb1.transform.position = new Vector2(screenBounds.x*-2.7f , 2.997f);
            lb2.transform.position = new Vector2(screenBounds.x*-2.7f , -2.737f);
        }
        IEnumerator wallWave(){
            while(true){
                yield return new WaitForSeconds(3.5f);
                spawnWall();
            }


    }
    }