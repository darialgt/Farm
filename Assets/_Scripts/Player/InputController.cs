using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private IControllable _controllable;

    private PlayerInputMap _playerInputMap;

    private void Awake()
    {
        _controllable = GetComponent<IControllable>();

        _playerInputMap = new PlayerInputMap();
        _playerInputMap.Enable();
    }

    private void OnEnable()
    {
        _playerInputMap.Player.Jump.performed += JumpOnperformed;
    }

    private void OnDisable()
    {
        _playerInputMap.Player.Jump.performed -= JumpOnperformed;
    }

    private void JumpOnperformed(InputAction.CallbackContext obj)
    {
        _controllable.Jump();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void ReadMovement()
    {
        var inputDirection = _playerInputMap.Player.Movement.ReadValue<Vector2>();
        var direction = new Vector3(inputDirection.x, 0, inputDirection.y);

        _controllable.Move(direction);
    }
}
