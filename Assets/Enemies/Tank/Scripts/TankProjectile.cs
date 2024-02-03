using System;
using UnityEngine;

public class TankProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private void Start()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
