using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private float comboDelay = 3f;
    [SerializeField] private float score;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private Animation textTransitionAnimation;
    private float _comboTimer = 0f;
    private float _comboMultiplier = 1f;
    public static PlayerScore Instance;

    private void Awake()
    {
        Instance = this;
    }

    public float Score
    {
        get { return score; }
        set
        {
            textTransitionAnimation.Play();
            scoreValue.text = value.ToString(CultureInfo.InvariantCulture);
            score = value;
        }
    }

    public void AddScore(float score)
    {
        Score += score * _comboMultiplier;
        _comboTimer = comboDelay;
        _comboMultiplier += 0.1f;
    }
    
    private  void Update()
    {
        if (_comboTimer > 0)
            _comboTimer -= Time.deltaTime;
        else _comboMultiplier = 1;
    }
}
