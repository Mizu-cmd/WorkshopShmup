using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 20;
    [SerializeField] private Image healthFill;
    [SerializeField] private Animation hitAnimation, lowLifeAnimation;
    [SerializeField] private PlayableDirector deathTimeline;
    public bool isShielded = false;
    public static PlayerHealth Instance;
    private float _healthPoint;
    public float HealthPoint
    {
        get => _healthPoint;
        set
        {
            if (_healthPoint <= 0 || isShielded) return;
            if (value <= maxHealth / 4)
                lowLifeAnimation.Play();
            DamagePlayer(value);
            _healthPoint = value;
        }
    }

    private void DamagePlayer(float value)
    {
        hitAnimation.Play();
        healthFill.fillAmount = value / maxHealth;
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
        deathTimeline.enabled = true;
        var mechCount = PlayerPrefs.GetInt("MechCount");
        PlayerPrefs.SetInt("MechCount", mechCount + 1);
    }
}
