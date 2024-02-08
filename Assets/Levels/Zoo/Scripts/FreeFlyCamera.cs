using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeFlyCamera : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float mouseSens = 100f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessLook();
    }

    private void ProcessMovement()
    {
        var motion = Vector3.zero;
        motion.x = Input.GetAxis("Horizontal");
        motion.z = Input.GetAxis("Vertical");
        transform.Translate(motion * speed * Time.deltaTime);
    }

    private void ProcessLook()
    {
        Vector2 mouseDelta = mouseSens * new Vector2( Input.GetAxis( "Mouse X" ), -Input.GetAxis( "Mouse Y" ) );
        Quaternion rotation = transform.rotation;
        Quaternion horiz = Quaternion.AngleAxis( mouseDelta.x, Vector3.up );
        Quaternion vert = Quaternion.AngleAxis( mouseDelta.y, Vector3.right );
        transform.rotation = horiz * rotation * vert;
    }
}
