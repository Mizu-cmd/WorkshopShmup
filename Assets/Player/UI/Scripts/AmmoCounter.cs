using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    private Weapon _primary, _secondary;
    private TextMeshPro _counter;
    public static AmmoCounter Instance;

    private void Start()
    {
        Instance = this;
        var player = GameObject.FindGameObjectWithTag("Player");
        _primary = player.GetComponentInChildren<PrimaryWeapon>();
        _secondary = player.GetComponentInChildren<SecondaryWeapon>();
        _counter = GetComponent<TextMeshPro>();
    }

    public void UpdateText()
    {
        _counter.text = $"{_primary.CurrentAmmo} I {_secondary.CurrentAmmo}";
    }
}
