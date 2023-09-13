using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f;

<<<<<<< HEAD
    private InputActions _inputActions;
=======
    private DefaultInputActions _inputActions;
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
    private Vector2 _moveInput;

    private void Awake()
    {
<<<<<<< HEAD
        _inputActions = new InputActions();
=======
        _inputActions = new DefaultInputActions();
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
        _inputActions.Enable();
        _inputActions.Player.Move.performed += OnMovePerformed;
        _inputActions.Player.Move.canceled += OnMoveCanceled;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
<<<<<<< HEAD
=======
        Debug.Log("OnMovePerformed: " + _moveInput);
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        _moveInput = Vector2.zero;
<<<<<<< HEAD
=======
        Debug.Log("OnMoveCanceled: " + _moveInput);
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
    }

    private void Update()
    {
<<<<<<< HEAD
        Vector3 moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y); // Change the Y component to the Z component
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime); // Use Translate instead of directly modifying position
=======
        Vector3 moveDirection = new Vector3(_moveInput.x, _moveInput.y, 0);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }
}
