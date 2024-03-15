using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanObstacle : MonoBehaviour
{
    public int ForceValue { private set; get; } = 100;

    [SerializeField]
    public CapsuleCollider collider;

    [SerializeField]
    public ParticleSystem activationPS;

    public void Init(int force)
    {
        ForceValue = force;
        name = $"Fan f={ForceValue}";
        collider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            //DynamicBallController.Instance.Bump(Vector3.up * ForceValue);
            activationPS.gameObject.SetActive(true);
            activationPS.Play();
            collider.enabled = false;
        }
    }
}
