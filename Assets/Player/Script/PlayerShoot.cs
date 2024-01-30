using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Weapon _primary, _secondary, _special;

    private void Start()
    {
        _primary = GetComponentInChildren<PrimaryWeapon>();
    }

    public void ShootPrimary()
    {
        _primary.Shoot();
    }

    public void ShootSecondary()
    {
        _secondary.Shoot();
    }
    
    public void ShootSpecial()
    {
        _special.Shoot();
    }
}
