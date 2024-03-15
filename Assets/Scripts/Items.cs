using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public float distanceFromCamera;
    Rigidbody r;
    [SerializeField] private float rotationSpeed;
  
    void Start()
    {
        distanceFromCamera = Vector3.Distance(this.gameObject.transform.position, Camera.main.transform.position);
        r = this.gameObject.GetComponent<Rigidbody>();
    }

    Vector3 lastPos;

    private void OnMouseDown()
    {
        r.useGravity = false;
        
        
    }
    void OnMouseDrag()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = distanceFromCamera;
        pos = Camera.main.ScreenToWorldPoint(pos);
        r.velocity = (pos - this.gameObject.transform.position)*20;
        r.MovePosition(new Vector3(r.position.x,0.5f,r.position.z));
        transform.RotateAroundLocal(new Vector3(2,1,1),2*Time.deltaTime);
    }
    
    void OnMouseUp()
    {
        r.velocity = Vector3.zero;
        r.useGravity = true;
        
    }
}
