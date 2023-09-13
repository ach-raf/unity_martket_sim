using UnityEngine;
using UnityEngine.InputSystem;

public class TileClickHandler : MonoBehaviour
{
<<<<<<< HEAD
    public Vector3 mousePosition;
=======
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
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
<<<<<<< HEAD
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
=======
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            
            IClickable clicked_object = hit.transform.GetComponent<IClickable>();
            if (clicked_object != null)
            {
                clicked_object.OnClick();
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
            }
        }
    }

    private void HandleRightClick(InputAction.CallbackContext context)
    {
<<<<<<< HEAD
        mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            IClickable clickedObject = hit.transform.GetComponent<IClickable>();
            if (clickedObject != null)
            {
                clickedObject.OnRightClick();
=======
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
        if (hit.collider != null)
        {
            IClickable clicked_object = hit.transform.GetComponent<IClickable>();
            if (clicked_object != null)
            {
                clicked_object.OnRightClick();
>>>>>>> f6fd120894f71c1625b5e8ddf5eadf906e769f04
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
