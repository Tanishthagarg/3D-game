 using UnityEngine;
 using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{

    
     void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerCharacter>().SavePlayer();
    if(GameManager.SharedInstance.GMLevel==1){
          SceneManager.LoadScene("IslandB");
          GameManager.SharedInstance.GMLevel=2;
    }
    else print("YOU WON");
    }
}
