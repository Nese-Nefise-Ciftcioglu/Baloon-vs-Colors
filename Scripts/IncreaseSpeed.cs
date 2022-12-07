using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeed : MonoBehaviour
{

    public GameObject blue;
    public GameObject red;
    public GameObject yellow;
    public GameObject littleBlackTop;
    public GameObject littleBlackBot;
    public GameObject hellium;
    public GameObject BlackBot;
    public GameObject BlackTop;
    public GameObject white;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreaseSpeedOfWalls", 1f, 10f);
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
        hs.speed = 9;

    }

    // Update is called once per frame
    void Update()
    {
        blueWall bs = blue.GetComponent<blueWall>();

        if (bs.speed >= 20)
            CancelInvoke();
    }


    void IncreaseSpeedOfWalls()
    {
        blueWall bs = blue.GetComponent<blueWall>();
        bs.speed = bs.speed + 0.5f;
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
        hs.speed = hs.speed + 0.5f;

    }


}
