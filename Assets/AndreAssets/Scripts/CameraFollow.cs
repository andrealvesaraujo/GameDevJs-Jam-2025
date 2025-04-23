using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public Vector3 offset; // Offset between camera and player (e.g., for slight elevation)
    public float smoothSpeed = 0.125f; // Smoothing factor for camera movement

    void LateUpdate()
    {
        // Desired position is player's position plus offset
        Vector3 desiredPosition = player.position + offset;
        // Keep the camera's z position (usually -10 for 2D)
        desiredPosition.z = transform.position.z;
        // Smoothly interpolate to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}