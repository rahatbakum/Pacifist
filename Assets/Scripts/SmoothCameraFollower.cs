using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollower : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [Space]
    [SerializeField] private Vector3 offset = new Vector3(0, 0, 0);
    [SerializeField] private bool isSaveCurrentOffsetOnStart = false;
    [SerializeField] private float speed = 10f;

    private float fixedZPosition;

    void Start()
    {
        if (isSaveCurrentOffsetOnStart)
        {
            offset = transform.position - targetObject.position;
        }

        fixedZPosition = transform.position.z;
    }

    void FixedUpdate()
    {
        if (Mathf.Abs(Vector2.Distance(transform.position, targetObject.position)) > 0.05f)
        {
            transform.position = Vector2.Lerp(transform.position, targetObject.position + offset, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, fixedZPosition);
        }
    }
}
