using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

public class RandomItems : MonoBehaviour
{

    [SerializeField] private GameObject[] items;
    public int itemCount;
    private int lastNumber;
    private List<int> intList = new List<int>();
    private Deneme _deneme;
    [SerializeField] private GameObject _main;
    private void Awake()
    {
        _deneme = _main.GetComponent<Deneme>();
        
    }


    private void Start()
    {
        ItemRandom();
        
        
        for (int i = 0; i < itemCount; i++)
        {
           int x;
           x = Random.Range(0,items.Length);
           while (intList.Contains(x))
           {
               x = Random.Range(0,items.Length);
           }
           
           
           intList.Add(x);
           
           var myNew = Instantiate(items[x], transform.position, transform.rotation);
           myNew.transform.parent = gameObject.transform;
        }
    }

    void ItemRandom()
    {
        if (Levels.level<40)
        {
            itemCount = _deneme._itemCount[Levels.level-1];
        }
        else
        {
            itemCount = _deneme._itemCount[Deneme._currentCount];
        }
    }
}
