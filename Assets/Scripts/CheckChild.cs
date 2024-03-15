using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckChild : MonoBehaviour
{
    private RandomItems _randomItems;
    public static int _activeItem;

    private void Awake()
    {
        _randomItems = GetComponent<RandomItems>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _activeItem = _randomItems.itemCount;
    }

    
}
