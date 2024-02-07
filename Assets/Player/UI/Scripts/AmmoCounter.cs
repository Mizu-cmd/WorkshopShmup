using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    private Weapon _primary, _secondary;

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        _primary = GetComponentInChildren<PrimaryWeapon>();
        _secondary = GetComponentInChildren<SecondaryWeapon>();
    }
}
