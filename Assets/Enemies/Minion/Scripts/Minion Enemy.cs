using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionEnemy : Enemy
{
    public override void Spawn()
    {
        throw new System.NotImplementedException();
    }

    private void Update()
    {
        EnemyController.Move(Vector3.left * Speed * Time.deltaTime);
        RotateTowardPlayer();
    }
}
