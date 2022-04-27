using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _rb;
    void Start()
    {
         _rb = GetComponent<Rigidbody2D>();
       Invoke("GoBall", 1);
        
    }

     void GoBall() {
      float rand = Random.Range(0, 2);
        if (rand < 1) {
        _rb.AddForce(new Vector2(300, 700));
        }
        else {
        _rb.AddForce(new Vector2(-300, 700));
        }
     }

      public void ResetBall() {

        _rb.velocity = Vector2.zero;
        transform.position = new Vector3(0,-3.29f,0);
    }

    public void Restart() {
        ResetBall();
        Invoke("GoBall", 1);
    }


    
    

  /*  private void OnCollisionEnter2D(Collision2D collision) {
 if (collision.gameObject.name =="Shotter") {
        float _paddle = GameObject.Find("Shotter").GetComponent<Transform>().position.x;
//Collision2D r= GameObject.Find("Player").GetComponent<Collision2D>().ToString;
        if(_paddle - transform.position.x < 0){_rb.velocity=new Vector2(50, 50);}
         if(_paddle - transform.position.x > 0){_rb.velocity=new Vector2(-50, 50);}
          if(_paddle - transform.position.x == 0){_rb.velocity=new Vector2(0, 5);}
    }
    
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
