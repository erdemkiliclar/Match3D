using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderL : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(2, 0, 0) * 120 * Time.deltaTime;
    }
}
