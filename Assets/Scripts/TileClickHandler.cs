using UnityEngine;
using UnityEngine.InputSystem;

public class TileClickHandler : MonoBehaviour
{
    public Vector3 mousePosition;
    private InputActions _inputActions;

    private void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.Enable();
        _inputActions.Player.Fire.performed += HandleFire;
        _inputActions.Player.RightClick.performed += HandleRightClick;
    }

    private void HandleFire(InputAction.CallbackContext context)
    {
        mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            IClickable clickedObject = hit.transform.GetComponent<IClickable>();
            if (clickedObject != null)
            {
                clickedObject.OnClick();
            }
            else
            {
                clickedObject = hit.transform.GetComponentInParent<IClickable>();
                clickedObject?.OnClick();
            }
        }
    }

    private void HandleRightClick(InputAction.CallbackContext context)
    {
        mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            IClickable clickedObject = hit.transform.GetComponent<IClickable>();
            if (clickedObject != null)
            {
                clickedObject.OnRightClick();
            }
        }
    }

    private void OnDisable()
    {
        _inputActions.Player.Fire.performed -= HandleFire;
        _inputActions.Player.RightClick.performed -= HandleRightClick;
        _inputActions.Disable();
    }
}
