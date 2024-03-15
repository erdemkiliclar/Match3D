using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    
    
    public float distanceFromCamera;
    Rigidbody r;
  
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
        r.velocity = (pos - this.gameObject.transform.position) * 10;
        r.MovePosition(new Vector3(r.position.x,0.5f,r.position.z));
    }
    
    void OnMouseUp()
    {
        r.useGravity = true;
    }
}