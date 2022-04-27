using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    GameObject g;
    public void Activate()
    {
          GameObject.Find("Dailog1").GetComponent<MeshRenderer>().enabled=true;
         
    }
    public void Deactivate()
    {
         GameObject.Find("Dailog1").GetComponent<MeshRenderer>().enabled=false;
    }
}
