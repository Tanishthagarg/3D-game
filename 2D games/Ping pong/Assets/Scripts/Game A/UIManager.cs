using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class UIManager : MonoBehaviour { 
    private int _playerScore1;
    private int _playerScore2;
    [SerializeField] private Text _p1Score;
    [SerializeField] private Text _p2Score;
    private int _gameWinScore = 10;
    [SerializeField] private Text _gameOverText;
    private GameObject _ball;

    void Start() {
        _ball = GameObject.Find("Ball");
    }

    public void Score(string wallID) {
        AudioSource audio = GetComponent<AudioSource>();

        if (wallID == "RightWall") {
            _playerScore1++;
            _p1Score.text = "" + _playerScore1;
            audio.Play();
        }
        else {
            _playerScore2++;
            _p2Score.text = "" + _playerScore2;
            audio.Play();
        }
        if (_playerScore1 < _gameWinScore && _playerScore2 < _gameWinScore) {
            _ball.GetComponent<BallControl>().Restart();
        }
        else
            GameOver();
    }

    public void GameOver() {
        if (_playerScore1 == _gameWinScore) {
            _gameOverText.text = "YOu WON";
        }
        else if (_playerScore2 == _gameWinScore) {
            _gameOverText.text = "YOU LOST";
        }
        _gameOverText.gameObject.SetActive(true);
        _ball.GetComponent<BallControl>().ResetBall();
    }

}
