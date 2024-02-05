using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SecondaryWeapon : Weapon
{
    [SerializeField] public AudioClip AudioShoot;
    [SerializeField] private SecondaryWeaponProjectile secondaryWeaponProjectile;
    private float _lastShot = 0f;
    
    public Transform targetTransform { get; set; }
    public override void Shoot()
    {
        if (targetTransform.IsDestroyed() || targetTransform == null) return;
        
        if (IsReloading) return;
        
        if (CurrentAmmo <= 0)
        {
            IsReloading = true;
            StartCoroutine(Reload());
            return;
        }
        
        if (!(Time.time > _lastShot + shootSpeed)) return;

        var projectile = Instantiate(secondaryWeaponProjectile, transform.position, quaternion.identity);
        projectile.spawnTransform = transform;
        projectile.targetTransform = this.targetTransform;
        projectile.SecondaryWeapon = this;
        
        _lastShot = Time.time;
        AudioSource.PlayClipAtPoint(AudioShoot, transform.position, 0.2f);
    }
}
