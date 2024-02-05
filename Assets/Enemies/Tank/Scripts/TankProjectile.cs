using System;
using UnityEngine;

public class TankProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    public EnemyTank Tank { get; set; }

    private void Start()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        Destroy(gameObject,3f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Tank.ProcessProjectileImpact();
    }
}
