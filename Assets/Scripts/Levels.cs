using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public static int level =1;


    [SerializeField] private TextMeshProUGUI _levelText;

   

    private void Awake()
    {

        level = PlayerPrefs.GetInt("Level", level);
        _levelText.text = "LEVEL: " + level;
    }
    
    
}
