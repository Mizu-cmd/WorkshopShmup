using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected bool IsReloading;
    [SerializeField] protected float damage, shootSpeed, reloadTime;
    [SerializeField] protected short magSize;
    private short _currentAmmo;
    [SerializeField] private ParticleSystem impactSystem;
    protected short CurrentAmmo
    {
        get { return _currentAmmo; }
        set { _currentAmmo = value; }
    }

    public void Start()
    {
        CurrentAmmo = magSize;
    }
    public abstract void Shoot();

    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        IsReloading = false;
        CurrentAmmo = magSize;
    }

    public virtual void HandleImpact(Vector3 impactPoint, Vector3 impactNormal)
    {
        var impact = Instantiate(impactSystem, impactPoint, Quaternion.Euler(impactNormal));
    }
    
    public virtual void HandleImpact(Vector3 impactPoint, Vector3 impactNormal, Enemy enemy)
    {
        enemy.Damage(damage);
        var impact = Instantiate(impactSystem, impactPoint, Quaternion.Euler(impactNormal));
    }
}
