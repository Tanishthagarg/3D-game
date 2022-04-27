using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private int _score=0;
    private int _lives=3;
    [SerializeField] private Text _playerscore;
    [SerializeField] private Text _playerlives;
    [SerializeField] private Text _gameOverText;
    

    GameObject _ship;


    void Start()
    {
        _ship=GameObject.Find("Ship");
    }

    public int Lives{
    get{
        return _lives;
    }
    set{
        _lives=value;
    }

    }

    public void livecount(){
       
     _lives--;

     _playerlives.text= "Lives: "+_lives;

     if(_lives==0){
           _gameOverText.text="GameOver";
           _gameOverText.gameObject.SetActive(true);
           GameObject.Find("Ship").GetComponent<ShipController>().enabled=false;

     }

    }

    public void scorecount(){

        _score=_score+10;
        _playerlives.text= "Score: "+ _score;

        if(_score==840){
           _gameOverText.text="LEVEL COMPLETED";
           _gameOverText.gameObject.SetActive(true);
           GameObject.Find("Ship").SetActive(false);

     }

    }
}
