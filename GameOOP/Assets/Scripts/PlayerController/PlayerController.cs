using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private PlayerInput inputActions;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction lookAction;

    private Vector2 inputM;
    private Vector2 inputL;

    [SerializeField] private Transform cam;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float lookSpeed = 5f;
    [SerializeField] private Rigidbody rb;



    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = GetComponent<PlayerInput>();

        moveAction = inputActions.actions.FindAction("Move");
        lookAction = inputActions.actions.FindAction("Look");
        
    }

    private void FixedUpdate()
    {
        inputM = moveAction.ReadValue<Vector2>();
        inputL = lookAction.ReadValue<Vector2>();

        rb.MovePosition(rb.position + transform.forward * inputM.y * moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + transform.right * inputM.x * moveSpeed * Time.fixedDeltaTime);

        var camDirection = cam.transform.forward;
        camDirection.y = 0;
        

        transform.forward = camDirection;
    }

    public void Move(InputAction.CallbackContext context)
    {
        switch (context.) 
        {
        
        }
    }
}
