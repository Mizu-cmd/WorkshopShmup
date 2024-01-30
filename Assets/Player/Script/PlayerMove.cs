using System;
using UnityEngine;

[DisallowMultipleComponent, RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    private CharacterController _characterController;
    
    public Vector2 Input { get; set; }
    private Vector2 _smoothedInput, _currentVelocity;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float acceleration = 0.15f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _smoothedInput = Vector2.SmoothDamp(_smoothedInput, Input, ref _currentVelocity, acceleration);
        var motion = Vector3.zero;
        motion.x = _smoothedInput.x;
        motion.z = _smoothedInput.y;
        _characterController.Move(motion * (speed * Time.deltaTime));
    }
}
