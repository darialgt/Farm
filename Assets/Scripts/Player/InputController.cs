using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private IControllable _controllable;

    private PlayerController _playerController;

    private void Awake()
    {
        _controllable = GetComponent<IControllable>();

        _playerController = new PlayerController();
        _playerController.Enable();
    }

    private void OnEnable()
    {
        _playerController.Player.Jump.performed += JumpOnperformed;
    }

    private void OnDisable()
    {
        _playerController.Player.Jump.performed -= JumpOnperformed;
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
        var inputDirection = _playerController.Player.Movement.ReadValue<Vector2>();
        var direction = new Vector3(inputDirection.x, inputDirection.y, 0);

        _controllable.Move(direction);
    }
}
