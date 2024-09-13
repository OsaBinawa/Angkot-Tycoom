using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float dragSpeed = 2; // Speed of camera movement
    private Vector3 dragOrigin; // Starting point of the drag
    public float fixedYPosition = 10f; // The fixed y position of the camera

    // Define the boundaries for the camera movement
    public float minX = -50f;
    public float maxX = 50f;
    public float minZ = -50f;
    public float maxZ = 50f;

    void Start()
    {
        // Set the initial fixed Y position if not already set in the Inspector
        transform.position = new Vector3(transform.position.x, fixedYPosition, transform.position.z);
    }

    void Update()
    {
        // Detect mouse press
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        // If the mouse button is not pressed, exit
        if (!Input.GetMouseButton(0)) return;

        // Calculate the difference between the start point and the current mouse position
        Vector3 difference = Input.mousePosition - dragOrigin;

        // Convert the difference to world units and apply the drag speed
        Vector3 move = new Vector3(difference.x * dragSpeed * Time.deltaTime, 0, difference.y * dragSpeed * Time.deltaTime);

        // Adjust the move direction based on camera orientation
        move = transform.TransformDirection(move);

        // Apply movement to the camera
        transform.position -= move;

        // Lock the Y position
        transform.position = new Vector3(transform.position.x, fixedYPosition, transform.position.z);

        // Clamp the camera position within the defined boundaries
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            fixedYPosition,
            Mathf.Clamp(transform.position.z, minZ, maxZ)
        );

        // Update the drag origin to the current mouse position
        dragOrigin = Input.mousePosition;
    }
}
