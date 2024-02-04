using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyTurret : Enemy
{
    [SerializeField] private GameObject molotov;
    [SerializeField] private float minProjectileForce, maxProjectileForce;
    
    public override void Spawn()
    {
        throw new System.NotImplementedException();
    }

    public override void Start()
    {
        base.Start();
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2);
        var molo = Instantiate(molotov, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
        var rb = molo.GetComponent<Rigidbody>();
        rb.AddForce(molo.transform.forward * Random.Range(minProjectileForce, maxProjectileForce));
        rb.AddTorque(Vector3.forward * 5);
    }
}
