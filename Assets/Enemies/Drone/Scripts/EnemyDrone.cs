using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDrone : Enemy
{

    [SerializeField] private float moveLenght = 5f;
    [SerializeField] private float minShootDelay, maxShootDelay;

    [SerializeField] private TrailRenderer bulletTrail;

    private RaycastHit _hit;
    
    
    public override void Spawn()
    {
        
    }

    public override void Start()
    {
        base.Start();
        StartCoroutine(ShootDelay());
    }

    public override void Destroy()
    {
        base.Destroy();
        print("destroyed");
    }

    private void Update()
    {
        RotateTowardPlayer();
        var motion = Vector3.zero;
        motion.z = moveLenght/2 - Mathf.PingPong(Time.time, moveLenght);
        EnemyController.Move(motion * (Speed * Time.deltaTime));
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
