using Unity.Mathematics;
using UnityEngine;

public class SecondaryWeapon : Weapon
{
    [SerializeField] private SecondaryWeaponProjectile secondaryWeaponProjectile;
    private float _lastShot = 0f;
    
    public Transform targetTransform { get; set; }
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

        var projectile = Instantiate(secondaryWeaponProjectile, transform.position, quaternion.identity);
        projectile.spawnTransform = transform;
        projectile.targetTransform = this.targetTransform;
        projectile.SecondaryWeapon = this;
        
        _lastShot = Time.time;
    }

    public void HandleImpact(Enemy enemy)
    {
        enemy.Damage(damage);
    }
}
