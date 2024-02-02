using System.Collections;
using UnityEngine;

public class EnemyTank : Enemy
{

    [SerializeField] private float reachDistance, minShotDelay, maxShotDelay;
    [SerializeField] private float rotationDelay = 2f;
    private Vector3 _motion, _currentVelocity;
    [SerializeField] private GameObject projectile, projectilSpawn;
    private Animator _animator;
    
    public override void Spawn()
    {
        
    }

    public override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, playerTransform.position);
        var rotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationDelay);
        if (distance >= reachDistance)
        {
            transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * Speed);
        }
 
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(Random.Range(minShotDelay, maxShotDelay));
        var position = projectilSpawn.transform.position;
        _animator.Play("Shoot", 0, 0f);
        
        var go = Instantiate(projectile, position, Quaternion.identity);
        go.transform.up = playerTransform.position - position;
        StartCoroutine(Shoot());
    }

    public override void Destroy()
    {
        
    }
}
