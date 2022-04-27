using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _sharedInstance;
    private int _health = 10;
    private int _coin =0;

    private int _GMlevel=1;

    public int GMLevel{
        get{
            return _GMlevel;
        }
        set{
            _GMlevel=value;
        }
    }

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }
    public int Coin
    {
        get
        {
            return _coin;
        }
        set
        {
            _coin = value;
        }
    }
    public static GameManager SharedInstance
    {
        get
        {
            return _sharedInstance;
        }
    }
    void Awake()
    {
        if (_sharedInstance == null)
        {
            DontDestroyOnLoad(gameObject);
            _sharedInstance = this;
        }
        else if (_sharedInstance != this)
        {
            Destroy(gameObject);
        }
    }
}
