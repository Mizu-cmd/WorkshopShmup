using System.Collections;
using Cinemachine;
using UnityEngine;

public class EnemyTank : Enemy
{

    [SerializeField] private float reachDistance, minShotDelay, maxShotDelay;
    [SerializeField] private GameObject projectile, turretBone;
    [SerializeField] private AudioClip shootClip;
    private Vector3 _motion, _currentVelocity;
    private Animator _animator;
    private CinemachineImpulseSource _impulseSource;
    private ParticleSystem _muzzleFlash;
    
    public override void Spawn()
    {
        
    }

    public override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        _impulseSource = GetComponent<CinemachineImpulseSource>();
        _muzzleFlash = GetComponentInChildren<ParticleSystem>();
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        var playerPosition = playerTransform.position;
        var mechPosition = transform.position;
        var distance = Vector3.Distance(mechPosition, playerPosition);
        
        turretBone.transform.LookAt(playerPosition);
        
        if (distance >= reachDistance)
        {
            playerPosition.y = mechPosition.y;
            transform.position = Vector3.Lerp(mechPosition, playerPosition,Time.deltaTime * Speed);
            RotateTowardPlayer();
            
            _animator.SetBool("Idle", false);
        } else _animator.SetBool("Idle", true);
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(Random.Range(minShotDelay, maxShotDelay));
        _animator.Play("Shoot", 1, 0f);
        _impulseSource.GenerateImpulse(0.2f);
        AudioSource.PlayClipAtPoint(shootClip ,transform.position, 0.1f);
        _muzzleFlash.Play();
        
        var go = Instantiate(projectile, BulletSpawn.transform.position, Quaternion.identity);
        StartCoroutine(Shoot());
    }
}
