using System;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerShoot : MonoBehaviour
{
    private Weapon _primary, _secondary, _special;
    private bool _shootSecondary;
    private VisualEffect _casingEffect;
    private void Start()
    {
        _primary = GetComponentInChildren<PrimaryWeapon>();
        _secondary = GetComponentInChildren<SecondaryWeapon>();
        _casingEffect = GetComponentInChildren<VisualEffect>();
    }

    public void Update() {
        if (_shootSecondary)
        {
            _casingEffect.SetVector3("SpawnPos", transform.position);
            _secondary.Shoot();
        }
    }

    public void ShootPrimary()
    {
        _primary.Shoot();
    }

    public void ShootSecondary()
    {
        _shootSecondary = true;
        _casingEffect.Play();
    }

    public void ReleaseSecondary()
    {
        _shootSecondary = false;
        GetComponentInChildren<VisualEffect>().Stop();
    }
    public void ShootSpecial()
    {
        _special.Shoot();
    }
}
