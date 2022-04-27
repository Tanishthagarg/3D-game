using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotterBehaviour : MonoBehaviour
{

    private float _speed = 17;
private float _boundary = 8.5f;
Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
         _rb = GetComponent<Rigidbody2D>();
       //  Invoke("Update",1);
    }

     public void ResetPaddle() {

       // _rb.velocity = Vector2.zero;
      // Invoke("Update",1);
        transform.position = new Vector3(0,-4.08f,0);
        
    }

    // Update is called once per frame
    void Update()
    {
                Vector2 vel = _rb.velocity;
        if (Input.GetKey(KeyCode.RightArrow)) {
        vel.x = _speed;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
        vel.x = -_speed;
        }
        else {
        vel.x = 0;
        }
        _rb.velocity = vel;
        Vector3 pos = transform.position;
        if (pos.x > _boundary) {
        pos.x = _boundary;
        }
        else if (pos.x < -_boundary) {
        pos.x = -_boundary;
        }
        transform.position = pos;
            }
}
