using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonPlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float rotationSmoothTime = 0.1f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 15f;

    [Header("References")]
    [SerializeField] private ThirdPersonCamera thirdPersonCamera;
    [SerializeField] private PlayerInput playerInput;

    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector3 currentVelocity;
    private float currentSpeed;
    private float turnSmoothVelocity;
    private bool isRunning;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        isRunning = context.performed;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 inputDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            // Get camera's forward direction (horizontal only)
            Quaternion cameraRotation = thirdPersonCamera.GetCameraForward();

            // Calculate movement direction relative to camera
            Vector3 targetDirection = cameraRotation * inputDirection;

            // Calculate target rotation
            float targetAngle = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSmoothTime);

            // Rotate player to face movement direction
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Determine target speed
            float targetSpeed = isRunning ? runSpeed : walkSpeed;

            // Accelerate
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.fixedDeltaTime);
        }
        else
        {
            // Decelerate when no input
            currentSpeed = Mathf.Lerp(currentSpeed, 0f, deceleration * Time.fixedDeltaTime);
        }

        // Calculate movement in player's forward direction
        Vector3 targetVelocity = transform.forward * currentSpeed;
        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);

        // Apply movement using MovePosition
        rb.MovePosition(rb.position + currentVelocity * Time.fixedDeltaTime);
    }
}