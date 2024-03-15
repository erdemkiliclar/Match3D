using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Deneme : MonoBehaviour
{

    public float[] _time;
    public int[] _itemCount;
    private int level;
    public static int _currentCount;
    public static int _currentTime;


    private void Awake()
    {
        int x;
        if (GameTime._gameOver==false)
        {
            x = Random.Range(5, 40);
            _currentCount = x;
            PlayerPrefs.SetInt("CurrentCount",_currentCount);
        }
        else
        {
            _currentCount = PlayerPrefs.GetInt("CurrentCount", _currentCount);
        }
        _currentTime = _currentCount;
        Debug.Log(_currentCount);
        Debug.Log("currenttime: "+_currentTime);
    }

    private void Start()
    {
        
    }
}
