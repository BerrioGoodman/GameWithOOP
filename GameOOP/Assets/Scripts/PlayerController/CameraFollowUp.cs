using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowUp : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.1f;
    private Vector3 offset;
    private Vector3 Velocity = Vector3.zero;
    public float distance = 1f;



    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            offset = target.forward * -2f;
            offset.y = offset.y + distance; // Adjust the height of the camera
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref Velocity, smoothTime);
        }
    }
}
