using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MatchMaker : MonoBehaviour
{

    public List<GameObject> PlacedObject = new List<GameObject>();
    public GameObject PointA,PointB;
    private GameObject _destroyPart;

    private void Awake()
    {
        
        _destroyPart = GameObject.FindGameObjectWithTag("DestroyPart");
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (PlacedObject.Count==0)
        {
            other.gameObject.transform.rotation = PointA.transform.rotation;
            other.gameObject.transform.position = PointA.transform.position;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            PlacedObject.Add(other.gameObject);
        }else if (other.gameObject.transform.name.Contains(PlacedObject[0].name)==true)
        {
            PlacedObject.Add(other.gameObject);
            _destroyPart.GetComponent<Renderer>().material = other.gameObject.GetComponent<Renderer>().material;
            for (int i = 0; i < 6; i++)
            {
                _destroyPart.transform.GetChild(i).GetComponent<Renderer>().material =
                    _destroyPart.GetComponent<Renderer>().material;
            }
            other.gameObject.transform.rotation = PointB.transform.rotation;
            other.gameObject.transform.position = PointB.transform.position;
            other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(Wait());
            
            
        }
        else
        {
            other.GetComponent<Rigidbody>().velocity = new Vector3(0, 2, 2) * 120 * Time.deltaTime;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(PlacedObject[1].gameObject);
        Destroy(PlacedObject[0].gameObject);
        _destroyPart.GetComponent<ParticleSystem>().Play();
        CheckChild._activeItem--;
        PlacedObject.Clear();
        
    }
    
    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        if (PlacedObject.Contains(other.gameObject))
        {
            PlacedObject.Remove(other.gameObject);
        }
    }


    
}
