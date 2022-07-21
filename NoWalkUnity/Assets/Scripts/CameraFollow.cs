using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 targetPos;
    public float smoothSpeed = 0.125f;
    // public Vector2 offset;

    private void Start()
    {
        targetPos = target.position;
        transform.position = new Vector3(targetPos.x, targetPos.y, -10);
    }
    void FixedUpdate()
    {
        targetPos = target.position;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
        transform.position = new Vector3 (smoothedPosition.x, smoothedPosition.y, -10);
    }
}
