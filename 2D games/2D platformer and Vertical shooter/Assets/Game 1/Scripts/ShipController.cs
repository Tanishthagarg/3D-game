using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class ShipController : MonoBehaviour{

    [SerializeField] GameObject _shot;
    [SerializeField] AudioClip a1;
     [SerializeField] AudioClip a2;

     bool shiplive=true;

    private float _speed = 5;
    private float _boundary = 3.5f;
    Rigidbody2D _rb;
    Animator _anime;

    void Start(){
        _rb = GetComponent<Rigidbody2D>();
        _anime=GetComponent<Animator>();
    }

    void Update(){
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

        if (shiplive&&Input.GetKeyDown(KeyCode.Space)) {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip=a1;
               audio.Play();
            Instantiate(_shot, new Vector3(transform.position.x,
                transform.position.y, 0.5f), Quaternion.identity);
        }
    }
    
    private async void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "AShot") {
            AudioSource audio = GetComponent<AudioSource>();
           audio.clip = a2;
           audio.Play();
          _anime.SetTrigger("GotShot");
          shiplive=false;
          GameObject.Find("Canvas").GetComponent<UIManager>().livecount();
                Destroy(other.gameObject);
                      GetComponent<BoxCollider2D>().enabled=false;

                      Invoke("Reset",2);
              }
    }

    private void Reset(){

         _anime.SetTrigger("GotShot");
         shiplive=true;
        GetComponent<BoxCollider2D>().enabled=true;
    }
}
