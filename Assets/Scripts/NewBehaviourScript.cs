using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] private GameObject _victoryPanel,victoryPart;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            
            _victoryPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            victoryPart.SetActive(true);
        }
    }
    
    
}
