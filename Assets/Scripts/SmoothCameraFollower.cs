using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollower : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private Vector2 offset = new Vector3(0, 0, 0);
    [SerializeField] private bool isSaveCurrentOffsetOnStart = false;
    [SerializeField] private float speed = 10f;

    void Start()
    {
        if (isSaveCurrentOffsetOnStart)
        {
            offset = transform.position - targetObject.position;
        }
    }

    void Update()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, targetObject.position)) > 0.05f)
            transform.position = Vector3.Lerp(transform.position, targetObject.position, speed * Time.deltaTime);
    }
}
