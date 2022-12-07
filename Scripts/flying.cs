using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class flying : MonoBehaviour
{
   
   public float gravity;
   public Rigidbody2D rb;
   public Vector2 startPos;
   //public static flying Instance{get; private set;}
    public void start() {
        //Instance=this;
        startPos =transform.position;
       rb=GetComponent<Rigidbody2D>();
       gravity=rb.gravityScale;
       }
   public void Update(){

        if (Input.GetMouseButton(0))
        {
           
            rb.AddForce(Vector2.up * gravity * Time.deltaTime * 1700f);
        }
        Vector2 vel=rb.velocity;
        float ang = Mathf.Atan2(vel.y,10)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,ang));
     

    }
   void OnTriggerEnter2D(Collider2D col){
       if(col.tag=="hellium"){
           SoundManagerScript.PlaySound("Hellium");
       StartCoroutine(Wait(10,col));
           
                Vector2 vel=rb.velocity;
                float ang = Mathf.Atan2(vel.y,10)*Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0,0,ang));
                if(Input.GetMouseButton(0)){
                rb.AddForce(Vector2.up*gravity*Time.deltaTime*2000f);
                }
                 Destroy(col.gameObject);

       
       }
       /*else if(col.gameObject.CompareTag("Coin")){
           CoinScript.coinAmount+=1;
           Instantiate(coinAn,transform.position,Quaternion.identity);
           SoundManagerScript.PlaySound("Coin");
           
           Destroy(col.gameObject);
           
           

       }*/
   }

    private IEnumerator Wait(float waitTime, Collider2D col)
    {
        if (col.tag == "hellium")
        {

            rb.gravityScale *= -1;
            gravity = -gravity;
            Vector2 vel = rb.velocity;
            float ang = Mathf.Atan2(vel.y, 10) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, ang));
        
        }
        yield return new WaitForSeconds(waitTime);
       

    }

}


  
