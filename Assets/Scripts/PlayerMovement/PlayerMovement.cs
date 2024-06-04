using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _camera;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private InputActionReference _actionReference;
    [SerializeField] private InputActionReference _jumpActionReference;
    [SerializeField] private Animator _animtor;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;
    private bool _isOnGround = true;

    private void OnEnable()
    {
        _jumpActionReference.action.performed += Jump;
        _jumpActionReference.action.Enable();
    }

    private void OnDisable()
    {
        _jumpActionReference.action.performed -= Jump;
        _jumpActionReference.action.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 input = _actionReference.action.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0f, input.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(_playerTransform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            _playerTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            Vector3 move = moveDir.normalized * _speed * Time.fixedDeltaTime;
            Vector3 newPosition = _rb.position + move;
            _rb.MovePosition(newPosition);
        }
        _animtor.SetFloat("WalkSpeed", Mathf.Abs(input.x) > Mathf.Abs(input.y) ? Mathf.Abs(input.x) : Mathf.Abs(input.y));
        Debug.Log(Mathf.Abs(input.x) > Mathf.Abs(input.y) ? Mathf.Abs(input.x) : Mathf.Abs(input.y));
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (_isOnGround)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Force);
            AudioSystem.instance.PlaySFX(AudioNames.Jump);
            _animtor.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isOnGround = false;
        }
    }
}
