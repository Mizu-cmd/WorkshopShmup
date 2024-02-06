using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadPickup : Pickup
{
    private Weapon mainWeapon, secondaryWeapon;

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        mainWeapon = player.GetComponentInChildren<PrimaryWeapon>();
        secondaryWeapon = player.GetComponentInChildren<SecondaryWeapon>();
    }

    public override void Collect()
    {
        mainWeapon.CurrentAmmo = mainWeapon.magSize;
        secondaryWeapon.CurrentAmmo = secondaryWeapon.magSize;
        Destroy(gameObject);
    }
}
