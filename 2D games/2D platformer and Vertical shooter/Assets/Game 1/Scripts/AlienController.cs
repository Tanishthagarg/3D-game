using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AlienController : MonoBehaviour{

    [SerializeField] GameObject _ashot;
  //  [SerializeField] AudioClip a;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Shot") {
            AudioSource audio = GetComponent<AudioSource>();
        //       audio.clip=a;
               audio.Play();
            Destroy(gameObject);
             GameObject.Find("Canvas").GetComponent<UIManager>().scorecount();
            Destroy(other.gameObject);
        }
    }

    private void Update() {
        if (Mathf.FloorToInt(Random.value * 10000.0f) % 5000 == 0) {
            Instantiate(_ashot, new Vector3(transform.position.x,
                transform.position.y, 0.5f), Quaternion.identity);
        }
    }
}
