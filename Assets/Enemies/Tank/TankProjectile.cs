using System;
using UnityEngine;

public class TankProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Vector3 _direction;

    private void Start()
    {
        var pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        _direction = pos - transform.position;
    }

    void Update()
    {
        transform.position =  Vector3.MoveTowards(transform.position, _direction, 0.5f);
    }
}
