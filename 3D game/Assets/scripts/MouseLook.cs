using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseLook : MonoBehaviour {
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    [SerializeField] private RotationAxes _axes = RotationAxes.MouseXAndY;
    [SerializeField] private float _sensitivityHor = 9.0f;
    [SerializeField] private float _sensitivityVert = 9.0f;
    [SerializeField] private float _minimumVert = -45.0f;
    [SerializeField] private float _maximumVert = 45.0f;
    private float _verticalRot = 0;
    void Start() {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) {
            body.freezeRotation = true;
        }
    }
    void Update() {
        if (_axes == RotationAxes.MouseX) {
            transform.Rotate(0, Input.GetAxis("Mouse X") *
            _sensitivityHor, 0);
        }
        else if (_axes == RotationAxes.MouseY) {
            _verticalRot -= Input.GetAxis("Mouse Y") *
            _sensitivityVert;
            _verticalRot = Mathf.Clamp(_verticalRot, _minimumVert,
            _maximumVert);
            float horizontalRot = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_verticalRot,
            horizontalRot, 0);
        }
        else {
            _verticalRot -= Input.GetAxis("Mouse Y") *
            _sensitivityVert;
            _verticalRot = Mathf.Clamp(_verticalRot, _minimumVert,
            _maximumVert);
            float delta = Input.GetAxis("Mouse X") * _sensitivityHor;
            float horizontalRot = transform.localEulerAngles.y +
            delta;
            transform.localEulerAngles = new Vector3(_verticalRot,
            horizontalRot, 0);
            }
    }
}