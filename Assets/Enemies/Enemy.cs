using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController)), DisallowMultipleComponent]
public abstract class Enemy : MonoBehaviour
{
    public CharacterController EnemyController { get; private set; }
    public Transform playerTransform { get; private set; }

    [SerializeField] private float health;

    public float Health
    {
        get { return health; }
        set
        {
            //update health bar
            if (value <= 0)
            {
                Destroy();
                return;
            }
            Health = value;
        }
    }
    [field: SerializeField] public float Speed { get; set; }
    
    [field : SerializeField] public GameObject BulletSpawn { get; set; }
    public virtual void Start()
    {
        EnemyController = GetComponent<CharacterController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public abstract void Spawn();

    public virtual void Damage(float damage)
    {
        Health -= damage;
    }
    public abstract void Destroy();
}
