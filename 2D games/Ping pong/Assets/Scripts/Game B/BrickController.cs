using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    // Start is called before the first frame update
    public static float _brickCount=0;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
if (other.gameObject.name == "Ball") {

        Rigidbody2D re= other.gameObject.GetComponent<Rigidbody2D>();
        Vector2 v=re.velocity;

        re.velocity= Vector2.zero;
        re.velocity=-v;
        Destroy(this.gameObject);
        _brickCount++;

         GameObject.Find("Canvas").GetComponent<UImanager>().score(_brickCount);

}
}



    // Update is called once per frame
    void Update()
    {
        
    }
}
