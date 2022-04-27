using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    private Camera _cam;
    private bool _haspistol=false;

    private IEnumerator SphereIndicator(Vector3 pos) {
        GameObject sphere =
        GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere.transform.Scale(1,1,1);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }
    void Start(){
          _cam = GetComponent<Camera>();
          Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
    }
    void Update() {
    
        
        if (Input.GetMouseButtonDown(0)) {
            Vector3 point = new Vector3(_cam.pixelWidth / 2,
            _cam.pixelHeight / 2, 0);
            Ray ray = _cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target =
                hitObject.GetComponent<ReactiveTarget>();
                if (target != null) {
                    target.ReactToHit();
                }
                else {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
        if((Input.GetKeyDown(KeyCode.W))&& _haspistol){
            Vector3 point = new Vector3(_cam.pixelWidth / 2,
            _cam.pixelHeight / 2, 0);
            Ray ray = _cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                GameObject hitObject = hit.transform.gameObject;
                BackAndForth target =
                hitObject.GetComponent<BackAndForth>();
                if (target != null) {

                   target.enabled=false;
                }
                else {
                    StartCoroutine(SphereIndicator(hit.point));
                }
        } 
    }
    }

     public void pistolshotter() {
       _haspistol=true;
       print("got pistol");
    }

    void OnGUI() {
        int size = 40;
        float posX = _cam.pixelWidth/2 - size/4;
        float posY = _cam.pixelHeight/2 - size/2;
        GUI.Label(new Rect(posX, posY, size, size), "+");
    }

}
