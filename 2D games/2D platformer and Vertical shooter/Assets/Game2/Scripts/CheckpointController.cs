using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject e;
        void Start()
    {
        GameObject.Find("FlyingEnemy1").GetComponent<FlyingEnemyController>().enabled=false;
       // GameObject.Find("FlyingEnemy1").GetComponent<FlyingEnemyController>().enabled=false;
         GameObject.Find("Enemy2").GetComponent<Enemy1Control>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
           collision.gameObject.GetComponent<PlayerController>()._startx=49.0f;
            GameObject.Find("FlyingEnemy1").GetComponent<FlyingEnemyController>().enabled=true;
            GameObject.Find("Enemy2").GetComponent<Enemy1Control>().enabled=true;
        }

}
}