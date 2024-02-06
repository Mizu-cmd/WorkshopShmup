using Cinemachine;
using UnityEngine;
using UnityEngine.VFX;

[DisallowMultipleComponent, RequireComponent(typeof(CinemachineImpulseSource))]
public abstract class Enemy : MonoBehaviour
{
    public CharacterController EnemyController { get; private set; }
    public Transform PlayerTransform { get; private set; }
    [SerializeField] protected float health, rotationDelay, damage;
    [SerializeField] private VisualEffect explosionVFX;
    protected CinemachineImpulseSource CinemachineImpulseSource;
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField, Min(0)]
    public float Score { get; private set; }
    public float Health
    {
        get => health;
        set
        {
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
        CinemachineImpulseSource = GetComponent<CinemachineImpulseSource>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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
        SpawnPickup();
        var explosion = Instantiate(explosionVFX, transform.position, transform.rotation);
        explosion.gameObject.SetActive(true);
        CinemachineImpulseSource.GenerateImpulse(0.1f);
        Destroy(gameObject);
    }

    private void SpawnPickup()
    {
        var multiplier = LevelManager.Instance.GetDropMultiplier();

        foreach (var p in LevelManager.Instance.pickups)
        {
            var random = Random.value;
            if (p.DropRate * multiplier >= random)
            {
                var enemyPos = transform.position;
                var pos = Vector3.zero;
                pos.x = Random.Range(-2, 2) + enemyPos.x;
                pos.z = Random.Range(-2, 2) + enemyPos.z;
                pos.y = 2;
                Instantiate(p, pos, p.transform.rotation);
            }
        }
    }

    public void RotateTowardPlayer()
    {
        var rotation = Quaternion.LookRotation(PlayerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationDelay);
    }

    public void DamagePlayer(float playerDamage)
    {
        PlayerHealth.Instance.HealthPoint -= playerDamage;
    }
}
