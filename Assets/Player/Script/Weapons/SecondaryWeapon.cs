using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class SecondaryWeapon : Weapon
{
    [SerializeField] private Transform bulletSpawn;
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

        var projectile = Instantiate(secondaryWeaponProjectile, bulletSpawn.position, quaternion.identity);
        projectile.spawnTransform = bulletSpawn;
        projectile.targetTransform = this.targetTransform;
        projectile.SecondaryWeapon = this;

        CurrentAmmo--;
        _lastShot = Time.time;
    }
}
