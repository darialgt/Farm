using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IControllable
{
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _groundDistance = 0.4f;
    [SerializeField] private float _jumpHeight = 3f;

    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _groundCheck;

    [SerializeField] private LayerMask _groundMask;

    private Vector3 _velocity;

    private bool _isGrounded;

    public void Jump()
    {
        if (_isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
    }

    public void Move(Vector3 direction)
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        _characterController.Move(direction * _speed * Time.deltaTime);

        _velocity.y += _gravity + Time.deltaTime;

        _characterController.Move(_velocity * Time.deltaTime);
    }
}
