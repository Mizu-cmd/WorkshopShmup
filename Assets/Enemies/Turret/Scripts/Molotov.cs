using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Molotov : MonoBehaviour
{
    [SerializeField] private ParticleSystem molotovFire;
    [SerializeField] private float minFireSize, maxFireSize;
    private CinemachineImpulseSource _cinemachineImpulseSource;

    private void Start()
    {
        _cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Floor")) return;
        
        _cinemachineImpulseSource.GenerateImpulse(0.1f);
        Instantiate(molotovFire, transform.position, molotovFire.transform.rotation);
        for (int i = 0; i < Random.Range(minFireSize, maxFireSize); i++)
        {
            var pos = Vector3.zero;
            pos.x = Random.Range(-3, 3);
            pos.z = Random.Range(-3, 3);
            
            Instantiate(molotovFire, transform.position + pos, molotovFire.transform.rotation);
        }
        Destroy(gameObject);
    }
}
