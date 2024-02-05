using System.Collections;
using UnityEngine;

public class PrimaryWeapon : Weapon
{
    private float _lastShot = 0f;
    private RaycastHit _hit;
    [SerializeField] private TrailRenderer bulletTrail;
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
        
        TrailRenderer trailRenderer = Instantiate(bulletTrail, transform.position, Quaternion.identity);
        Ray ray = new Ray(transform.position, transform.forward);
        
        if (Physics.Raycast(ray, out _hit, 50))
            StartCoroutine(SpawnTrail(trailRenderer, _hit.point, true));
        else 
            StartCoroutine(SpawnTrail(trailRenderer, transform.forward * 100, false));
        _lastShot = Time.time;
        CurrentAmmo--;
        
        AudioSource.PlayClipAtPoint(AudioShoot, transform.position, 0.2f);
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
            HandleImpact(hitPoint, _hit.normal);
            Enemy enemy;
            if (_hit.transform.gameObject != null && _hit.transform.gameObject.TryGetComponent(out enemy))
                enemy.Damage(damage);
        }
        Destroy(trail.gameObject, trail.time);
    }
}
