using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTarget : MonoBehaviour
{
    public static LinkedListNode<Transform> CurrentEnemy { get; set; }
    public static LinkedList<Transform> Enemies { get; set; }
    private static SecondaryWeapon _weapon;

    private void Start()
    {
        _weapon = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<SecondaryWeapon>();
        Enemies = new LinkedList<Transform>();
    }

    public static void SelectNext()
    {
        if (CurrentEnemy.Next != null) CurrentEnemy = CurrentEnemy.Next;
        else CurrentEnemy = Enemies.Last;
        
        _weapon.targetTransform = CurrentEnemy.Value;
    }

    public static void SelectPrevious()
    {
        if (CurrentEnemy.Previous != null) CurrentEnemy = CurrentEnemy.Previous;
        else CurrentEnemy = Enemies.First;
            _weapon.targetTransform = CurrentEnemy.Value;
    }

    public static void StartSelect()
    {
        CurrentEnemy = Enemies.First;
        _weapon.targetTransform = CurrentEnemy.Value;
    }
}
