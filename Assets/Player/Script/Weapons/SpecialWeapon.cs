using UnityEngine;

public class SpecialWeapon : Weapon
{
    public float specialProgress { get; set; } = 0f;

    [SerializeField] private GameObject Bomb;
    
    public override void Shoot()
    {
        
    }
}
