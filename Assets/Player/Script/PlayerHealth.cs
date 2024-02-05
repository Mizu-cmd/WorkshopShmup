using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private Image healthFill;
    public static PlayerHealth Instance;
    private float _healthPoint;
    public float HealthPoint
    {
        get => _healthPoint;
        set
        {
            DamagePlayer(value);
            _healthPoint = value;
        }
    }

    private void DamagePlayer(float value)
    {
        if (value <= 0)
        {
            Die();
            return;
        }
        healthFill.fillAmount = value / maxHealth;
        
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        HealthPoint = maxHealth;
    }

    private void Die()
    {
        
    }
}
