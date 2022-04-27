using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{

    private int _health;
    private int _coin;
    [SerializeField] Text healthScore;
    [SerializeField] Text CoinScore;
    void Start()
    {
        //_health = 10;
        healthScore.text= " " +GameManager.SharedInstance.Health;
        CoinScore.text=" " +GameManager.SharedInstance.Coin;
        _health = GameManager.SharedInstance.Health;
    }
    public void Hurt(int damage)
    {
        _health -= damage;
        print("Health: " + _health);
        healthScore.text = " " + _health;
    }
    public void Heal(int energy)
    {
        _health += energy;
        print("Health: " + _health);
        healthScore.text = " " + _health;
    }

    public void SavePlayer()
    {
        GameManager.SharedInstance.Health = _health;
        GameManager.SharedInstance.Coin = _coin;
        
    }

    public void Countcoin(){
        _coin++;
        CoinScore.text=" " + _coin;
    }
}