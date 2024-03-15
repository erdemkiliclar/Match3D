using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    [SerializeField] private GameObject _goPanel;
    [SerializeField] private GameObject _victoryPanel;
    public static bool _gameOver=false;
    public float timeDuration;
    private float timer;
    private Deneme _deneme;
    
    private void Awake()
    {
        _deneme = GetComponent<Deneme>();
    }

    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI seperator;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI secondSecond;


    private void Start()
    {
        if (Levels.level<40)
        {
            timeDuration = _deneme._time[Levels.level - 1];
        }
        else
        {
            timeDuration = _deneme._time[Deneme._currentTime];
        }
        ResetTimer();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
            if (timer>0 && CheckChild._activeItem==0)
            {
                
                _victoryPanel.SetActive(true);
                
                timer += Time.deltaTime;
                
            }
        }
        else
        {
            timer = 0;
            UpdateTimerDisplay(timer);
            if (timer == 0 && CheckChild._activeItem>0)
            {
                _gameOver = true;
                _goPanel.SetActive(true);
                Time.timeScale = 0;
            }
 
        }
    }

    void ResetTimer()
    {
        timer = timeDuration;
    }
    void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();

    }
    
    
    
}
