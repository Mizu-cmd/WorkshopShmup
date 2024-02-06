using System;
using System.Collections;
using UnityEngine;

public class ShieldPickup : Pickup
{
    [SerializeField] private float duration;
    [SerializeField] private GameObject shieldMesh;
    private GameObject _shield;
    private bool activated = true;
    public override void Collect()
    {
        if (!activated || PlayerHealth.Instance.isShielded) return;
        PlayerHealth.Instance.isShielded = true;
        _shield = Instantiate(shieldMesh, GameObject.FindGameObjectWithTag("Player").transform);
        GetComponentInChildren<MeshRenderer>().enabled = false;
        activated = true;
        StartCoroutine(StartShield());
    }

    private IEnumerator StartShield()
    {
        yield return new WaitForSeconds(duration);
        PlayerHealth.Instance.isShielded = false;
        Destroy(_shield);
    }
}
