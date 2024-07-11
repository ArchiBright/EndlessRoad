using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BordersFollow : MonoBehaviour

// Limit car movement inside the road
{
    [SerializeField] private Transform player;
    public Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.z = player.position.z + offset.z;
        transform.position = newPosition;
    }
}
