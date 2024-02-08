using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [field: SerializeField]
    public float DropRate { get; private set; }
    public abstract void Collect();

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) Collect();
    }

    private void Update()
    {
        transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
    }
}
