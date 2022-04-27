using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class GroundLayer3 : MonoBehaviour
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
            print("YOU WON");
           }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") ) {
            PolygonCollider2D _layer2Collider=GameObject.Find("GroundLayer2").GetComponent<PolygonCollider2D>();
            GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineConfiner>().m_BoundingShape2D=_layer2Collider;
        }
    }
}
