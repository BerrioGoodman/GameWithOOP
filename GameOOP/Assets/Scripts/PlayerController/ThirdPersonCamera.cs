using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Transform player;
    [SerializeField] private float distanceFromPlayer = 5f;
    [SerializeField] private float minVerticalAngle = -30f;
    [SerializeField] private float maxVerticalAngle = 70f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 1.5f, 0);

    private float currentX = 0f;
    private float currentY = 0f;
    private Vector2 lookInput;

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        // Apply mouse input with sensitivity
        currentX += lookInput.x * rotationSpeed * Time.deltaTime;
        currentY -= lookInput.y * rotationSpeed * Time.deltaTime;

        // Clamp vertical rotation
        currentY = Mathf.Clamp(currentY, minVerticalAngle, maxVerticalAngle);

        // Calculate rotation and position
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = new Vector3(0, 0, -distanceFromPlayer);
        Vector3 position = rotation * direction + player.position + cameraOffset;

        // Apply to camera
        transform.position = position;
        transform.rotation = rotation;
    }

    public Quaternion GetCameraForward()
    {
        return Quaternion.Euler(0, currentX, 0);
    }
}