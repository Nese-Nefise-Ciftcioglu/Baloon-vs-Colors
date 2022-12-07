using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class deployBlack : MonoBehaviour
    {
        public GameObject BlackBot;
        public GameObject BlackTop;
        public GameObject white;
    
        public float rewpawnTime=3.0f;
        private Vector2 screenBounds;
        

        

        // Start is called before the first frame update
      
        void Start()
        {
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width,Screen.height,Camera.main.transform.position.z));
            StartCoroutine(wallWave());
}
        private void spawnWall(){
            GameObject top = Instantiate(BlackTop) as GameObject;
             GameObject whi = Instantiate(white) as GameObject;
            GameObject bottom = Instantiate(BlackBot) as GameObject;
           

            top.transform.position = new Vector2(screenBounds.x *-2, 5.16f);
             whi.transform.position = new Vector2(screenBounds.x *-2, -0.13f);
            bottom.transform.position = new Vector2(screenBounds.x *-2, -5.42f);
           
         
        }
        IEnumerator wallWave(){
            int counter=0;
            while(counter==0){
                yield return new WaitForSeconds(3);
                spawnWall();
                counter++;
                
            }


    }
    }