using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected bool IsReloading;
    [SerializeField] protected float damage, shootSpeed, reloadTime;
    [SerializeField] protected short magSize;
    private short _currentAmmo;
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
}
