using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SecondaryWeaponProjectile : MonoBehaviour
{
    public Transform spawnTransform { get; set; }
    public Transform targetTransform { get; set; }
    
    [SerializeField] private float journeyTime = 1.0f;
    private float startTime;
    private Vector3 offset;
    public SecondaryWeapon SecondaryWeapon { get; set; }

    private void Start()
    {
        startTime = Time.time;
        offset = Vector3.zero;
        offset.x = Random.Range(-10, 10);
        offset.y = Random.Range(-10, 10);
        offset.z = Random.Range(-10, 10);
    }

    public void Update()
    {
        // The center of the arc
        Vector3 center = (spawnTransform.position + targetTransform.position) * 0.5F;

        // move the center a bit downwards to make the arc vertical
        center -= offset;

        // Interpolate over the arc relative to center
        Vector3 riseRelCenter = spawnTransform.position - center;
        Vector3 setRelCenter = targetTransform.position - center;

        // The fraction of the animation that has happened so far is
        // equal to the elapsed time divided by the desired time for
        // the total journey.
        float fracComplete = (Time.time - startTime) / journeyTime;
        
        transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
        transform.position += center;

        if (fracComplete >= 1)
        {
            var enemy = targetTransform.GetComponent<Enemy>();
            SecondaryWeapon.HandleImpact(enemy);
            Destroy(gameObject);
        }
    }
}
