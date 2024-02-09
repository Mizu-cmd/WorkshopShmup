using System;
using Unity.VisualScripting;
using UnityEngine;

public class TankProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    public EnemyTank Tank { get; set; }

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player!= null && !player.IsDestroyed())
            transform.LookAt(player.transform);
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
