 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class matchDedector : MonoBehaviour
{
    public GameObject srk;
    SpriteRenderer spriteRenderer;

    public GameObject DieEffect;
    public SpriteRenderer sr;
    public SpriteRenderer whitesr;
    public string currentColor;
    public Color colorYellow;
    public Color colorBlue;
    public Color colorRed;
    public Color colorOrange;
    public Color colorGreen;
    public Color colorPurple;
    public Color bgColor;
    public Color bgDarkColor;
    public GameObject deployBlack;
    public GameObject deployWalls;
    public GameObject BlackBot;
    public GameObject BlackTop;
    public GameObject white;
    public GameObject backGround;
    public GameObject Heart;
    private Vector2 screenBounds;
    public int counter=0;
    public SpriteRenderer srbg;
    public static int score;
    public GameObject blue;
    public GameObject red;
    public GameObject yellow;

    public GameObject littleBlackTop;
    public GameObject littleBlackBot;
    public GameObject hellium;

    public GameObject sceneManager;

    GameObject HeartInst;
    // Start is called before the first frame update
    void Start()
    {

        HeartInst = Instantiate(Heart, new Vector3(-12.515f, 7.339f, 0f), Quaternion.identity);
        srk = GameObject.FindWithTag("backGroundPrefab");
        spriteRenderer = srk.GetComponent<SpriteRenderer>();
        int gameStartTime = (int)Time.time;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3 (Screen.width,Screen.height,Camera.main.transform.position.z));
        SetRandomColor();
        /*InvokeRepeating("IncreaseSpeed", 1f, 10f);
        blueWall bs = blue.GetComponent<blueWall>();
        bs.speed = 9;
        redWall rs = red.GetComponent<redWall>();
        rs.speed = 9;
        yellowWall ys = yellow.GetComponent<yellowWall>();
        ys.speed = 9;
        litBlack blts = littleBlackTop.GetComponent<litBlack>();
        blts.speed = 9;
        litBlack blbs = littleBlackBot.GetComponent<litBlack>();
        blbs.speed = 9;

        blackTop blbt = BlackTop.GetComponent<blackTop>();
        blbt.speed = 9; ;
        blackBot blbb = BlackBot.GetComponent<blackBot>();
        blbb.speed = 9; ;
        whitePart ws = white.GetComponent<whitePart>();
        ws.speed = 9; ;
        Hellium hs = hellium.GetComponent<Hellium>();
        hs.speed=9;*/
        




    }

    void Update()
    {
        /*blueWall bs = blue.GetComponent<blueWall>();
        
        if (bs.speed>=20)
            CancelInvoke();*/

        if (counter >= 10)
        {

            
            HeartInst.SetActive(true);
        }
        else if (counter == 0)
        {
           
           HeartInst.SetActive(false);
        }
   
        score = Score.scoreAmount;


    }

    

    void OnTriggerEnter2D(Collider2D col){

        
        if (col.tag == currentColor)
        {
            GameObject other = col.gameObject;
            col.GetComponent<BoxCollider2D>().enabled = false;
           

                StartCoroutine(setColActive(0.25f, col,other));      

            counter++;
            SoundManagerScript.PlaySound("Coin");
            Score.scoreAmount += 1;
            //col.gameObject.transform.localScale+=new Vector3(0.4f,0.2f,1);
            //StartCoroutine(ExecuteAfterTimeScaleChange(0.25f,col.gameObject));
            StartCoroutine(ExecuteAfterTime(0.25f));

                if (col.tag == "Blue")
                {
               
                    blueWall bp = col.gameObject.GetComponent<blueWall>();
                    bp.particle();
             

              }
                else if (col.tag == "Red")
                {
               

                    redWall rp = col.gameObject.GetComponent<redWall>();
                    rp.particle();
                   

            }
                else if (col.tag == "Yellow")
                {
               
                    yellowWall yp = col.gameObject.GetComponent<yellowWall>();
                    yp.particle();
      

            }
            



        }
            
            
       
        

       else if (col.tag == "topSpike" || col.tag == "botSpike")
        {
            // srbg.color = bgDarkColor;

            HeartInst.SetActive(false);
            spriteRenderer.color = bgDarkColor;
            SoundManagerScript.PlaySound("Die");
            Instantiate(DieEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            if (PlayerPrefs.GetFloat("Highscore") < score)
            {
                PlayerPrefs.SetFloat("Highscore", score);
                PlayServices leaderboard = sceneManager.GetComponent<PlayServices>();
                leaderboard.AddScoreToLeaderboard();
            }

            FindObjectOfType<RestartButtonManager>().EndGame();


        }


        else if (col.tag != currentColor)
        {
            if (counter >= 10)
            {
                if (currentColor == "Yellow" && col.tag == "Red")
                {
                    spriteRenderer.color = bgDarkColor;
                    col.gameObject.transform.localScale += new Vector3(0.25f, 0, 1);

                    sr.color = colorOrange;
                    currentColor = "Orange";

                    StartCoroutine(wallWave());
                    whitesr.color = colorOrange;



                }
                else if (currentColor == "Red" && col.tag == "Yellow")
                {
                    spriteRenderer.color = bgDarkColor;
                    col.gameObject.transform.localScale += new Vector3(0.25f, 0, 1);
                    sr.color = colorOrange;
                    currentColor = "Orange";

                    StartCoroutine(wallWave());
                    whitesr.color = colorOrange;


                }
                else if (currentColor == "Blue" && col.tag == "Yellow")
                {
                    spriteRenderer.color = bgDarkColor;
                    col.gameObject.transform.localScale += new Vector3(0.25f, 0, 1);
                    sr.color = colorGreen;
                    currentColor = "Green";

                    StartCoroutine(wallWave());
                    whitesr.color = colorGreen;


                }
                else if (currentColor == "Yellow" && col.tag == "Blue")
                {
                    spriteRenderer.color = bgDarkColor;
                    col.gameObject.transform.localScale += new Vector3(0.25f, 0, 1);
                    sr.color = colorGreen;
                    currentColor = "Green";

                    StartCoroutine(wallWave());
                    whitesr.color = colorGreen;

                }
                else if (currentColor == "Red" && col.tag == "Blue")
                {
                    spriteRenderer.color = bgDarkColor;
                    col.gameObject.transform.localScale += new Vector3(0.25f, 0, 1);
                    sr.color = colorPurple;
                    currentColor = "Purple";

                    StartCoroutine(wallWave());
                    whitesr.color = colorPurple;


                }
                else if (currentColor == "Blue" && col.tag == "Red")
                {
                    spriteRenderer.color = bgDarkColor;
                    col.gameObject.transform.localScale += new Vector3(0.25f, 0, 1);
                    sr.color = colorPurple;
                    currentColor = "Purple";

                    StartCoroutine(wallWave());
                    whitesr.color = colorPurple;
                }
                else if (col.tag == "white")
                {
                    SoundManagerScript.PlaySound("Hit");
                    StartCoroutine(ExecuteAfterTime(0.25f));
                    spriteRenderer.color = bgColor;
                    counter = 0;
                }
                else if (col.tag == "black" || col.tag == "black2")
                {
                    HeartInst.SetActive(false);
                    spriteRenderer.color = bgDarkColor;
                    SoundManagerScript.PlaySound("Die");
                    Instantiate(DieEffect, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    if (PlayerPrefs.GetFloat("Highscore") < score)
                    {
                        PlayerPrefs.SetFloat("Highscore", score);
                        PlayServices leaderboard = sceneManager.GetComponent<PlayServices>();
                        leaderboard.AddScoreToLeaderboard();
                    }



                    FindObjectOfType<RestartButtonManager>().EndGame();

                }

            }

            else if (currentColor == "Yellow" && col.tag == "Red" || currentColor == "Red" && col.tag == "Yellow")
            {
                HeartInst.SetActive(false);

                spriteRenderer.color = bgDarkColor;
                SoundManagerScript.PlaySound("Die");
                Instantiate(DieEffect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                if (PlayerPrefs.GetFloat("Highscore") < score)
                {
                    PlayerPrefs.SetFloat("Highscore", score);
                    PlayServices leaderboard = sceneManager.GetComponent<PlayServices>();
                    leaderboard.AddScoreToLeaderboard();
                }

                FindObjectOfType<RestartButtonManager>().EndGame();


            }
            else if (currentColor == "Blue" && col.tag == "Red" || currentColor == "Red" && col.tag == "Blue")
            {
                HeartInst.SetActive(false);
                spriteRenderer.color = bgDarkColor;
                SoundManagerScript.PlaySound("Die");
                Instantiate(DieEffect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                if (PlayerPrefs.GetFloat("Highscore") < score)
                {
                    PlayerPrefs.SetFloat("Highscore", score);
                    PlayServices leaderboard = sceneManager.GetComponent<PlayServices>();
                    leaderboard.AddScoreToLeaderboard();
                }

                FindObjectOfType<RestartButtonManager>().EndGame();


            }
            else if (currentColor == "Yellow" && col.tag == "Blue" || currentColor == "Blue" && col.tag == "Yellow")
            {
                HeartInst.SetActive(false);
                spriteRenderer.color = bgDarkColor;
                SoundManagerScript.PlaySound("Die");
                Instantiate(DieEffect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                if (PlayerPrefs.GetFloat("Highscore") < score)
                {
                    PlayerPrefs.SetFloat("Highscore", score);
                    PlayServices leaderboard = sceneManager.GetComponent<PlayServices>();
                    leaderboard.AddScoreToLeaderboard();
                }

                FindObjectOfType<RestartButtonManager>().EndGame();



            }


        }
      

                

    }

    /*void IncreaseSpeed()
    {
            blueWall bs = blue.GetComponent<blueWall>();
            bs.speed=bs.speed+0.5f;
            redWall rs = red.GetComponent<redWall>();
            rs.speed = rs.speed + 0.5f;
            yellowWall ys = yellow.GetComponent<yellowWall>();
            ys.speed = ys.speed + 0.5f;
            litBlack blts = littleBlackTop.GetComponent<litBlack>();
            blts.speed = blts.speed + 0.5f;
            litBlack blbs = littleBlackBot.GetComponent<litBlack>();
            blbs.speed = blbs.speed + 0.5f;
            blackTop blbt = BlackTop.GetComponent<blackTop>();
            blbt.speed = blbt.speed + 0.5f;
            blackBot blbb = BlackBot.GetComponent<blackBot>();
            blbb.speed = blbb.speed + 0.5f;
            whitePart ws = white.GetComponent<whitePart>();
            ws.speed = ws.speed + 0.5f;
            Hellium hs = hellium.GetComponent<Hellium>();
            hs.speed=hs.speed+0.5f;
        
    }*/

    void SetRandomColor (){

        int index = Random.Range(0,3);
        switch(index)
        {
        case 0:
            currentColor="Yellow";
            sr.color=colorYellow;
            break;
        case 1:
            currentColor="Blue";
            sr.color=colorBlue;
            break;
        case 2:
            currentColor="Red";
            sr.color=colorRed;
            break;


        }
    }
    IEnumerator ExecuteAfterTime(float time){
        yield return new WaitForSeconds(time);
        
        SetRandomColor();
    }

    IEnumerator setColActive(float time,Collider2D col,GameObject other)
    {
        yield return new WaitForSeconds(time);

        if (other != null)
        {
            col.GetComponent<BoxCollider2D>().enabled = true;
        }
        
        
    }





    private void spawnWall(){
            GameObject top = Instantiate(BlackTop) as GameObject;
             GameObject whi = Instantiate(white) as GameObject;
            GameObject bottom = Instantiate(BlackBot) as GameObject;
           

            top.transform.position = new Vector2(screenBounds.x *-0.1f, 5.16f);
            whi.transform.position = new Vector2(screenBounds.x *-0.1f, -0.13f);
            bottom.transform.position = new Vector2(screenBounds.x *-0.1f, -5.42f);
           
         
        }
        
        IEnumerator wallWave(){
            int c=0;
            while(c==0){
                yield return new WaitForSeconds(0.0001f);
                spawnWall();
                c++;
                
            }


    }
   
    
}
