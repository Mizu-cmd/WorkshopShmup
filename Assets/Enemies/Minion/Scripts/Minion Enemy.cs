using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MinionEnemy : Enemy
{
    [SerializeField] private float minShootDelay, maxShootDelay;
    [SerializeField] public AudioClip AudioShoot;
    [SerializeField] private TrailRenderer bulletTrail;
    
    private RaycastHit _hit;
    
    public override void Spawn()
    {
        throw new System.NotImplementedException();
    }

    public override void Start()
    {
        base.Start();
        BulletSpawn = gameObject.transform.GetChild(0).gameObject;
        StartCoroutine(ShootDelay());
    }

    private void Update()
    {
        EnemyController.Move(Vector3.left * Speed * Time.deltaTime);
        RotateTowardPlayer();
    }
    
    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(Random.Range(minShootDelay, maxShootDelay));
        Shoot();
        StartCoroutine(ShootDelay());
    }

    private void Shoot()
    {
        var position = BulletSpawn.transform.position;
        TrailRenderer trailRenderer = Instantiate(bulletTrail, position, Quaternion.identity);
        Ray ray = new Ray(position, transform.forward);
        
        if (Physics.Raycast(ray, out _hit, 50))
            StartCoroutine(SpawnTrail(trailRenderer, _hit.point, true));
        else 
            StartCoroutine(SpawnTrail(trailRenderer, transform.forward * 100, false));
    }
    
    IEnumerator SpawnTrail(TrailRenderer trail, Vector3 hitPoint, bool madeImpact)
    {
        AudioSource.PlayClipAtPoint(AudioShoot, transform.position, 1.0f);
        Vector3 startPosition = trail.transform.position;

        var distance = Vector3.Distance(startPosition, hitPoint);
        var startingDistance = distance;

        while (distance > 0)
        {
            trail.transform.position = Vector3.Lerp(startPosition, hitPoint, 1 - (distance / startingDistance));
            distance -= Time.deltaTime * 100;

            yield return null;
        }

        trail.transform.position = hitPoint;

        if (madeImpact)
        {
            DamagePlayer(damage);
        }
        Destroy(trail.gameObject, trail.time);
    }
}
