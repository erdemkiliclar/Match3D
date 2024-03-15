using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSinus : MonoBehaviour {

    [SerializeField] float speed = 10f;
    [SerializeField] Vector3 minPosition = Vector3.zero;
    [SerializeField] Vector3 maxPosition = Vector3.up;
    [SerializeField] Transform target;
    
    private float progress = 0f;
    
	void Update ()
	{
		progress += speed * Time.deltaTime;
		target.transform.localPosition = Vector3.Lerp(minPosition, maxPosition, 0.5f + 0.5f * Mathf.Sin(progress));
	}
}
