using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ConfineCamera : MonoBehaviour
{

    PolygonCollider2D _pc;
    // Start is called before the first frame update
    void Start()
    {
        _pc = GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineConfiner>().m_BoundingShape2D=_pc;
            GameObject.Find("Enemy2SpawnPoint").GetComponent<SpawnPoint>().enabled=true;
            GameObject.Find("Enemy2.1SpawnPoint").GetComponent<SpawnPoint>().enabled=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")&& collision.gameObject.GetComponent<Transform>().position.x<10.0f) {
            PolygonCollider2D _layer1Collider=GameObject.Find("GroundLayer").GetComponent<PolygonCollider2D>();
            GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineConfiner>().m_BoundingShape2D=_layer1Collider;
        }
    }
}
