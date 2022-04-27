using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected bool _isFacingRight = false;
     protected bool _isFacingUp = false;
    
    protected float _maxSpeed = 1.5f;
    protected Rigidbody2D _rb;
    public void Start() {
         _rb = GetComponent<Rigidbody2D>();
    }
    public void Flip() {
        _isFacingRight = !_isFacingRight;
        Vector3 enemyScale = transform.localScale;
        enemyScale.x = enemyScale.x * -1;
        transform.localScale = enemyScale;
    }
    
    public void VerticleFlip() {
        _isFacingUp = !_isFacingUp;
        Vector3 enemyScale = transform.localScale;
        enemyScale.y = enemyScale.y * -1;
        transform.localScale = enemyScale;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
