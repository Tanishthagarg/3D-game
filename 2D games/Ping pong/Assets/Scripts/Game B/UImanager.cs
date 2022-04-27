using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UImanager : MonoBehaviour
{

    private int _lives=3;
    private int _Score;
     private Text _WonOver;

    [SerializeField] private Text _pScore;
    [SerializeField] private Text _plives;
    [SerializeField] private Text _gameWonOver;

    float s=0;

    private GameObject _ball;
    private GameObject _paddle;
    private GameObject _brick;
    //float a=0;

    void Start() {
        _ball = GameObject.Find("Ball");
        _paddle= GameObject.Find("Shotter");
        _brick= GameObject.Find("BricksFactory");
        live();
      //  score();
    }

        public void score( float a){
           // a= _brick.GetComponent<BrickController>()._brickCount;
           if(a>s){
               _Score= _Score+10;
               _pScore.text=""+ _Score;
               s++;

           }

           if(_Score==160){
             //  _WonOver= "You Won";
               _gameWonOver.text="You Won";
                _gameWonOver.gameObject.SetActive(true);
_paddle.GetComponent<ShotterBehaviour>().ResetPaddle();
 _ball.GetComponent<BallController>().ResetBall();

           }


        }
    public void live(){

        if(_ball.gameObject.GetComponent<Transform>().position.y < -5.5f){

             _ball.GetComponent<BallController>().Restart();
              _paddle.GetComponent<ShotterBehaviour>().ResetPaddle();
             _lives--;
                _plives.text="" + _lives;


        }
        if(_lives<1){
             _ball.GetComponent<BallController>().ResetBall();
              _paddle.GetComponent<ShotterBehaviour>().ResetPaddle();
            
            _gameWonOver.text="You Lost";
             _gameWonOver.gameObject.SetActive(true);

        
        }
    }
    // Update is called once per frame
    void Update()
    {

      live();
               


        } 
    }

