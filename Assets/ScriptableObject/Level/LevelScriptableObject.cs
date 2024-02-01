using UnityEngine;

[CreateAssetMenu(menuName = "custom/LevelWave", fileName = "LevelScriptableObject"), System.Serializable]
public class LevelScriptableObject : ScriptableObject
{
    [System.Serializable]
    public struct WaveData
    {
        public bool[] row;
    }
    
    [Header("Nombres d'ennemis par manches")]
    [Tooltip("Nombre d'ennemis Minion")] public AnimationCurve MinionCount;
    [Tooltip("Nombre d'ennemis Drone")] public AnimationCurve DroneCount;
    [Tooltip("Nombre d'ennemis Tank")] public AnimationCurve TankCount;
    [Tooltip("Nombre d'ennemis Lanceur de molotov")] public AnimationCurve turretCount;
    
    [Header("Stats")]
    [Tooltip("Multiplicateur des hp des ennemis en fonction de la manche")] public AnimationCurve HPMultiplicator;
    [Tooltip("Multiplicateur des chances de drops des bonus en fonction de la manche")] public AnimationCurve BonusMultiplicator;

    public WaveData[] waves = new WaveData[3];
}