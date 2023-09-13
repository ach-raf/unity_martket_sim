using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private InputActions _inputActions;
    private Vector2 _moveInput;

    private void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.Enable();
        _inputActions.Player.Move.performed += OnMovePerformed;
        _inputActions.Player.Move.canceled += OnMoveCanceled;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y); // Change the Y component to the Z component
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime); // Use Translate instead of directly modifying position
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }
}
