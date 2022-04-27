using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    private float _speed = 3.0f;
     private Animator _anim;
    bool _isAlive;
    [SerializeField] private GameObject _fireballPrefab;
    private GameObject _fireball;
    private float _obstacleRange = 5.0f;

    void Start()
    {
        _isAlive = true;
        _anim = GetComponent<Animator>();
    }

    public void SetAlive(bool alive)
    {
        _isAlive = alive;
    }
    void Update()
    {
        if (_isAlive)
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);
           _anim.SetFloat("Speed", 2);
        }

        //_anim.SetFloat("Speed", 2);
        //transform.Translate(0, 0, _speed * Time.deltaTime);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 1.25f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (_fireball == null)
                {
                    _fireball = Instantiate(_fireballPrefab) as GameObject;
                    _fireball.transform.position =
                    transform.TransformPoint(2,3,3);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < _obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
