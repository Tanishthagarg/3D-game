using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class GameChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    public void Tennis() {  
        SceneManager.LoadScene("PartA");  
    }  


    public void TileBraker() {  
        SceneManager.LoadScene("PartB");
    }

     public void Menu() {  
        SceneManager.LoadScene("Menu");
    }

    public void Quit() {  
       Application.Quit();  
       print("Game exit");
    }  
      
      

    // Update is called once per frame
    void Update()
    {
       
    }
}
