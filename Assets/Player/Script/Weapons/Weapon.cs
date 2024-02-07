using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected bool IsReloading;
    [SerializeField] protected float damage, shootSpeed, reloadTime;
    [SerializeField] public short magSize;
    private short _currentAmmo;
    [SerializeField] private ParticleSystem impactSystem;
    [SerializeField] public AudioClip AudioReload;
    public short CurrentAmmo
    {
        get { return _currentAmmo; }
        set
        {
            _currentAmmo = value;
            AmmoCounter.Instance.UpdateText();
        }
    }

    public void Start()
    {
        CurrentAmmo = magSize;
    }
    public abstract void Shoot();

    public IEnumerator Reload()
    {
        AudioSource.PlayClipAtPoint(AudioReload, transform.position, 1.0f);
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
