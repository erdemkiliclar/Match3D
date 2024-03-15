using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    public GameObject _collider1,_collider2;


    private void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        _collider1.SetActive(false);
        _collider2.SetActive(false);
    }



}
