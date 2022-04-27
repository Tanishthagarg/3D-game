using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    [SerializeField] private float _speed = 6.0f;
    [SerializeField] private float _jumpSpeed = 15.0f;
    [SerializeField] private float _gravity = -9.8f;
    [SerializeField] private float _terminalVelocity = -10.0f;
    [SerializeField] private float _minFall = -1.5f;
    private float _vertSpeed;
    private CharacterController _charController;
    void Start() {
         _vertSpeed = _minFall;
        _charController = GetComponent<CharacterController>();
    }
    void Update() {
        float deltaX = Input.GetAxis("Horizontal") * _speed;
        float deltaZ = Input.GetAxis("Vertical") * _speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, _speed);
        movement.y = _gravity;

       //  if (deltaX != 0 || deltaZ != 0)
         {
        if (_charController.isGrounded)
        {
            if (Input.GetMouseButtonDown(1))
            {
                _vertSpeed = _jumpSpeed;
            }
            else
            {
                _vertSpeed = _minFall;
            }
        }
        else
        {
            _vertSpeed += _gravity * 5 * Time.deltaTime;
            if (_vertSpeed < _terminalVelocity)
            {
                _vertSpeed = _terminalVelocity;
            }
        }
        }
        movement.y=_vertSpeed;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);


        _charController.Move(movement);
    }
}
