using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [field : SerializeField]
    public float DropRate { get; private set; }
    public abstract void Collect();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }
}
