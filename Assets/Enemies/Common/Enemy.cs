using System;
using Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

[DisallowMultipleComponent, RequireComponent(typeof(CinemachineImpulseSource))]
public abstract class Enemy : MonoBehaviour
{
    public CharacterController EnemyController { get; private set; }
    public Transform playerTransform { get; private set; }
    [SerializeField] private float health, rotationDelay;
    [SerializeField] private VisualEffect explosionVFX;
    private CinemachineImpulseSource _cinemachineImpulseSource;
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField, Min(0)]
    public float Score { get; private set; }
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
            health = value;
        }
    }
    [field : SerializeField] public GameObject BulletSpawn { get; set; }
    public virtual void Start()
    {
        EnemyController = GetComponent<CharacterController>();
        _cinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public abstract void Spawn();

    public virtual void Damage(float damage)
    {
        Health -= damage;
    }

    public virtual void Destroy()
    {
        PlayerScore.Instance.AddScore(Score);
        LevelManager.Instance.EnemyCount -- ;
        var transform = explosionVFX.transform;
        var explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        explosion.gameObject.SetActive(true);
        _cinemachineImpulseSource.GenerateImpulse(0.1f);
        Destroy(gameObject);
    }

    public void RotateTowardPlayer()
    {
        var rotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationDelay);
    }
}
