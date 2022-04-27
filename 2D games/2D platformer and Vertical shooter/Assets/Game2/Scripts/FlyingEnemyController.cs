using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : EnemyController
{
    // Start is called before the first frame update
    void FixedUpdate() {
        if (_isFacingUp == true) {
        _rb.velocity =
        new Vector2( _rb.velocity.x,_maxSpeed*2.0f);
        }
        else {
        _rb.velocity =
        new Vector2( _rb.velocity.x,_maxSpeed * -1.2f);
        }

    }

     void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Wall") {
        VerticleFlip();
        }
    }
    
}
