using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PrimaryWeapon : Weapon
{
    private float _lastShot = 0f;
    private RaycastHit _hit;
    [SerializeField] private TrailRenderer bulletTrail;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] public AudioClip AudioShoot;
    
    public override void Shoot()
    {
        
        if (IsReloading) return;

        
        if (CurrentAmmo <= 0)
        {
            IsReloading = true;
            StartCoroutine(Reload());
            return;
        }
        
        if (!(Time.time > _lastShot + shootSpeed)) return;

        var position = bulletSpawn.position;
        TrailRenderer trailRenderer = Instantiate(bulletTrail, position, Quaternion.identity);
        Ray ray = new Ray(position, transform.forward);
        
        if (Physics.Raycast(ray, out _hit, 50))
            StartCoroutine(SpawnTrail(trailRenderer, _hit.point, true));
        else 
            StartCoroutine(SpawnTrail(trailRenderer, transform.forward * 100, false));
        _lastShot = Time.time;
        CurrentAmmo--;
    }
    
    IEnumerator SpawnTrail(TrailRenderer trail, Vector3 hitPoint, bool madeImpact)
    { 
        Vector3 startPosition = trail.transform.position;
        AudioSource.PlayClipAtPoint(AudioShoot, transform.position, 1.0f);
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
            HandleImpact(hitPoint, _hit.normal);
            if (!_hit.transform.gameObject.IsDestroyed())
            {
                Enemy enemy;
                if (_hit.transform.gameObject.TryGetComponent(out enemy))
                {
                    enemy.Damage(damage);
                }
            }
        }
        Destroy(trail.gameObject, trail.time);

    }
}
