using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class BallControl : MonoBehaviour
{
    private Rigidbody2D _rb;

    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
      
    }


        
    void GoBall() {
      
        float rand1 = Random.Range(15, 35);
        float rand2 = Random.Range(10, 20);
         float rand1direction = Random.Range(0, 2);
          float rand2direction = Random.Range(0, 2);
        if (rand1direction < 1) {
           rand1= -rand1;
        }
        if (rand2direction < 1) {
           rand2= -rand2;
        }
       
            _rb.AddForce(new Vector2(rand1, rand2));
    
    }

    public void ResetBall() {

        _rb.velocity = Vector2.zero;
        transform.position = Vector3.zero;
    }

    public void Restart() {
        ResetBall();
        Invoke("GoBall", 1);
    }


//Collision2D r= GameObject.Find("Player").GetComponent<Collision2D>();
private void OnCollisionEnter2D(Collision2D collision) {
  
 if (collision.gameObject.name =="Player") {
        float _paddle = GameObject.Find("Player").GetComponent<Transform>().position.y;
//Collision2D r= GameObject.Find("Player").GetComponent<Collision2D>().ToString;
        if(_paddle - transform.position.y < 0){_rb.velocity=new Vector2(5, 5);}
         if(_paddle - transform.position.y > 0){_rb.velocity=new Vector2(5, -5);}
          if(_paddle - transform.position.y == 0){_rb.velocity=new Vector2(5, 0);}
    }
   
AudioSource audio = GetComponent<AudioSource>();
audio.Play();
}

}
