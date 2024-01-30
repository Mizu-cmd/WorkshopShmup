using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public class PlayerInput : MonoBehaviour
{
    private PlayerMove _playerMove;
    private PlayerShoot _playerShoot;
    void Start()
    {
        _playerMove = GetComponent<PlayerMove>();
        _playerShoot = GetComponent<PlayerShoot>();
    }

    public void InputMovement(InputAction.CallbackContext ctx)
    {
        _playerMove.Input = ctx.ReadValue<Vector2>();
    }
    
    public void InputPrimary(InputAction.CallbackContext ctx)
    {
        _playerShoot.ShootPrimary();
    }
    
    public void InputSecondary(InputAction.CallbackContext ctx)
    {
        _playerShoot.ShootSecondary();
    }
    
    public void InputSpecial(InputAction.CallbackContext ctx)
    {
        _playerShoot.ShootSpecial();
    }
    
    public void InputPause(InputAction.CallbackContext ctx)
    {
        
    }
}
