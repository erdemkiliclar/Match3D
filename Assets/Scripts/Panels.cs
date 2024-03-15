using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Panels : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private void Update()
    {
        Gec();
    }

    private void Awake()
    {
        Time.timeScale = 1;
        
    }


    public void PauseButton()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        GameTime._gameOver = true;
        SceneManager.LoadScene(0);
    }


    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void ResumeButton()
    {
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }

    public void NextLevel()
    {
        GameTime._gameOver = false;
        Levels.level += 1;
        PlayerPrefs.SetInt("Level",Levels.level);
        SceneManager.LoadScene(0);
    }
    
    public void Gec()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Levels.level += 1;
            PlayerPrefs.SetInt("Level",Levels.level);
            SceneManager.LoadScene(0);
        }
    }
}
