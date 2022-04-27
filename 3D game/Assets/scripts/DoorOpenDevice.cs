using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenDevice : MonoBehaviour
{
    [SerializeField] Vector3 _dPos;
    private bool _isOpen;
    public void Operate()
    {
        if (_isOpen)
        {
            Vector3 pos = transform.position - _dPos;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position + _dPos;
            transform.position = pos;
        }
        _isOpen = !_isOpen;
    }

    public void Activate()
    {
        if (!_isOpen)
        { // open the door if it isn't already open
            Vector3 pos = transform.position + _dPos;
            transform.position = pos;
            _isOpen = true;
        }
    }
    public void Deactivate()
    {
        if (_isOpen)
        { // close the door if it isn't already closed
            Vector3 pos = transform.position - _dPos;
            transform.position = pos;
            _isOpen = false;
        }
    }
}
