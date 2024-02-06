using UnityEngine;

public class HealthPickup : Pickup
{

    [SerializeField] private float healthGain;
    
    public override void Collect()
    {
        PlayerHealth.Instance.HealthPoint += healthGain;
        Destroy(gameObject);
    }
}
