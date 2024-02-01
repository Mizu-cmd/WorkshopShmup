using Array2DEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "custom/LevelWave", fileName = "LevelScriptableObject"), System.Serializable]
public class LevelScriptableObject : ScriptableObject
{
    [Header("Stats")]
    [Tooltip("Multiplicateur des hp des ennemis en fonction de la manche")] public AnimationCurve HPMultiplicator;
    [Tooltip("Multiplicateur des chances de drops des bonus en fonction de la manche")] public AnimationCurve BonusMultiplicator;
    public Array2DEnemyEnum[] EnemyWaves;
}

public enum EnemyEnum {None, Drone, Tank, Minion, Turret}