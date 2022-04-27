using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] _targets;
    void OnTriggerEnter(Collider other)
    {
        foreach (GameObject target in _targets)
        {
            target.SendMessage("Activate");
        }
    }
    void OnTriggerExit(Collider other)
    {
        foreach (GameObject target in _targets)
        {
            target.SendMessage("Deactivate");
        }
    }
}
