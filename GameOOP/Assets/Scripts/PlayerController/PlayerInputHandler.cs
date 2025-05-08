using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private ThirdPersonCamera thirdPersonCamera;
    [SerializeField] private ThirdPersonPlayerMovement playerMovement;

    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction runAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        // Get references to actions
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
        runAction = playerInput.actions["Run"];

        // Set up callbacks
        moveAction.performed += ctx => playerMovement.OnMove(ctx);
        moveAction.canceled += ctx => playerMovement.OnMove(ctx);

        lookAction.performed += ctx => thirdPersonCamera.OnLook(ctx);
        lookAction.canceled += ctx => thirdPersonCamera.OnLook(ctx);

        runAction.performed += ctx => playerMovement.OnRun(ctx);
        runAction.canceled += ctx => playerMovement.OnRun(ctx);
    }

    private void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        runAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
        runAction.Disable();
    }
}
