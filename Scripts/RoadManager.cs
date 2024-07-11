using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private GameObject[] plane; // Array to hold road segments
    [SerializeField] private float roadSegmentLength = 10f; // Length of each road segment
    [SerializeField] private Transform player; // Reference to the car's transform

     void Update()
    {
        foreach (GameObject segment in plane)
        {
            // Check if the segment is behind the car
            if (segment.transform.position.z < player.position.z - roadSegmentLength)
            {
                // Reposition the segment in front
                Vector3 newPosition = segment.transform.position;
                newPosition.z += roadSegmentLength * plane.Length;
                segment.transform.position = newPosition;
            }
        }
    }
}
