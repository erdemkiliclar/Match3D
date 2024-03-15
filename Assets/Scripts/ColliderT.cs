using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderT : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        collision.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -2) * 120 * Time.deltaTime;
    }
}
