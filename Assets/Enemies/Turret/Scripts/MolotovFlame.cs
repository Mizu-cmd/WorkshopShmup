using System;
using UnityEngine;

public class MolotovFlame : MonoBehaviour
{
    [SerializeField] private float damage = 2f;
    private bool _insideFire = false;
    private float _timer = 0.5f;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = PlayerHealth.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _insideFire = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _insideFire = false;
    }

    private void Update()
    {
        if (_insideFire)
            _timer -= Time.deltaTime;
        
        if (_timer <= 0)
        {
            _playerHealth.HealthPoint -= damage;
            _timer = 0.5f;
        }
    }
}
