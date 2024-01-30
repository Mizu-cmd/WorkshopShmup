using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Weapon _primary, _secondary, _special;
    private bool _shootSecondary;
    private void Start()
    {
        _primary = GetComponentInChildren<PrimaryWeapon>();
    }

    public void Update() {
        if (_shootSecondary) print("secondary");
    }

    public void ShootPrimary()
    {
        _primary.Shoot();
    }

    public void ShootSecondary()
    {
        _shootSecondary = true;
    }

    public void ReleaseSecondary()
    {
        _shootSecondary = false;
    }
    public void ShootSpecial()
    {
        _special.Shoot();
    }
}
