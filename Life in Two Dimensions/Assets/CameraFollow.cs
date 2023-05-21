using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the cat's transform
    public float smoothness = 6f; // Controls the smoothness of the camera movement

    private Vector3 offset; // Offset between the camera and the cat

    private void Start()
    {
        // Calculate the initial offset between the camera and the cat
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        // Calculate the target position for the camera to move towards
        Vector3 targetPosition = target.position + offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness);
    }
}
