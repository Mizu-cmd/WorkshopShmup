using System;
using UnityEngine;

public class TankProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private void Start()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        Destroy(gameObject,3f);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
            print("player touched by tank");
    }
}
