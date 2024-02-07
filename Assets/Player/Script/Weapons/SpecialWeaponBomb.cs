using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeaponBomb : MonoBehaviour
{
    [SerializeField] private float timeBeforeExplode;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(timeBeforeExplode);
        
    }
}
