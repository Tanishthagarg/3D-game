using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; 

public class KeySelection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
             SceneManager.LoadScene("PartA"); 
        
        }
        if(Input.GetKeyDown(KeyCode.B)){
             SceneManager.LoadScene("PartB"); 
        
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            Application.Quit();  
           print("Game exit");
        
        }

         if(Input.GetKeyDown(KeyCode.Escape)){
             SceneManager.LoadScene("Menu"); 
        
        }
    }
}
