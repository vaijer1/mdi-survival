using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour

{
    Transform playerTransform;
    public float offset;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 camPosition = transform.position;
        camPosition.x = playerTransform.position.x + offset;
        transform.position = camPosition;
    }
}
