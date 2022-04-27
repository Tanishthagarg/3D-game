using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float _speed= 4.5f;
    float _jumpForce= 12.0f;
    bool _isGrounded;

    public float _startx=-4.75f; 
    public float _starty=-1.49f;


    Rigidbody2D _rb;

    Animator _anime;

    // Start is called before the first frame update
    void Start()
    {
        _rb=GetComponent<Rigidbody2D>();
        _anime = GetComponent<Animator>();
        _isGrounded=true;
    }

    // Update is called once per frame
    void Update()
    {

        float deltaX = Input.GetAxis("Horizontal") * _speed;
        Vector2 movement = new Vector2(deltaX, _rb.velocity.y);
        _rb.velocity = movement;

        _anime.SetFloat("_speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX, 0)) {
                transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
        if (_isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    void restart(){
         
        transform.position= new Vector3(_startx,_starty,0);
       /* if(_startx>40.0f){
             GameObject.Find("FlyingEnemy1").GetComponent<FlyingEnemyController>().enabled=false;
        // GameObject.Find("Enemy2").GetComponent<Enemy1Control>().enabled=false;
         GameObject.Find("Enemy2").GetComponent<Transform>().position=new Vector3(25.24f,1.67f,10.76565f);

        }*/
        gameObject.SetActive(true);
    }



    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") {
            _isGrounded = true;
        }

        if (collision.gameObject.tag == "Finish") {
           print("LEVEL COMPLETED");
        }

         if (collision.gameObject.tag == "Enemy") {

              // Destroy(this.gameObject);
             gameObject.SetActive(false);
             Invoke("restart",2);

           
           // collision.gameObject.GetComponent<Rigidbody2D>().velocity=Vector3.zero;
        }

}
private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") {
            _isGrounded = false;
}
}
}
