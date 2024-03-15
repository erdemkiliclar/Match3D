using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPart : MonoBehaviour
{
    [SerializeField] GameObject _victoryPart;

    private void Awake()
    {
        _victoryPart.SetActive(true);
    }
}
