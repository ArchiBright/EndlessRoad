using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
// Camera follow the player
{
    [SerializeField] private Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset between the camera and the player

    void Start()
    {
        // Initialize the offset
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // Update the camera's position
        transform.position = player.position + offset;
    }
}

