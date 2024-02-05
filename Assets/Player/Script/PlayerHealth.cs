using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private Image healthFill;
    [SerializeField] private Animation hitAnimation, lowLifeAnimation;
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
        hitAnimation.Play();
        healthFill.fillAmount = value / maxHealth;
        if (_healthPoint <= maxHealth / 10)
            lowLifeAnimation.Play();
        if (value <= 0)
            Die();
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _healthPoint = maxHealth;
    }

    private void Die()
    {
        
    }
}
