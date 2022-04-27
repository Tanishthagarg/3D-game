using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentController : MonoBehaviour
{
    
   
    
    [SerializeField] private float _speed = 2.4f;
    private float _boundary = 2.25f;
    Rigidbody2D _rb;

    void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        // moves the paddle up or down when key pressed
        Vector2 vel = _rb.velocity;
        
  Vector3 pos1 = transform.position;
          float _currentposition;
      _currentposition =    GameObject.Find("Ball").GetComponent<Transform>().position.y - pos1.y;
      if ( _currentposition > 0.25){    //used 0.25 to stop the jigling of the paddle
       vel.y = _speed;
      }

      else if ( _currentposition < 0){
       vel.y =  -_speed;
      }

        else {
            vel.y = 0;
        }
        _rb.velocity = vel;

        // limits movement at boundaries
        Vector3 pos = transform.position;
        if (pos.y > _boundary) {
            pos.y = _boundary;
        }
        else if (pos.y < -_boundary) {
            pos.y = -_boundary;
        }
        transform.position = pos;
    }

}
