using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private float comboDelay = 3f;
    private float _comboTimer = 0f;
    private float _comboMultiplier = 1f;
    [SerializeField] private float score;
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
            //code interface
            score = value;
        }
    }

    public void AddScore(float score)
    {
        Score += score * (_comboMultiplier/10);
        _comboTimer = comboDelay;
        _comboMultiplier++;
    }
    
    private  void Update()
    {
        if (_comboTimer > 0)
            _comboTimer -= Time.deltaTime;
        
        print(_comboTimer);
    }
}
