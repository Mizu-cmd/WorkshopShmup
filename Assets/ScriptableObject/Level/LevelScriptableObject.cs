using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "custom/LevelWave", fileName = "LevelScriptableObject")]
public class LevelScriptableObject : ScriptableObject
{
    [Header("Nombres d'ennemis par manches")]
    [Tooltip("Nombre d'ennemis Minion")] public AnimationCurve MinionCount;
    [Tooltip("Nombre d'ennemis Drone")] public AnimationCurve DroneCount;
    [Tooltip("Nombre d'ennemis Tank")] public AnimationCurve TankCount;
    [Tooltip("Nombre d'ennemis Lanceur de molotov")] public AnimationCurve turretCount;
    
    [Header("Stats")]
    [Tooltip("Multiplicateur des hp des ennemis en fonction de la manche")] public AnimationCurve HPMultiplicator;
    [Tooltip("Multiplicateur des chances de drops des bonus en fonction de la manche")] public AnimationCurve BonusMultiplicator;
}
