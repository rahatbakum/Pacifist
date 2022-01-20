using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollower : MonoBehaviour
{
    public Transform targetObject;
    [Space]
    public Vector3 offset = new Vector3(0, 0, 0);
    public bool isSaveCurrentOffsetOnStart = false;
    public float speed = 10f;
    
    private float fixedZPosition;
    private float minTargetCameraSize;
    private Rigidbody2D targetRigidBody;
    private Camera thisCamera;

    void Start()
    {
        if (isSaveCurrentOffsetOnStart)
        {
            offset = transform.position - targetObject.position;
        }

        fixedZPosition = transform.position.z;

        targetRigidBody = targetObject.GetComponent<Rigidbody2D>();

        thisCamera = GetComponent<Camera>();

        minTargetCameraSize = thisCamera.orthographicSize;
    }

    void FixedUpdate()
    {
        moveCamera();
    }

    Vector3 calculateDesirePosition()
    {
        Vector3 ans = targetObject.position + offset;
        ans = new Vector3(ans.x, ans.y, fixedZPosition);

        return ans;
    }

    void moveCamera()
    {
        if (Mathf.Abs(Vector2.Distance(transform.position, targetObject.position)) > 0.05f)
        {
            transform.position = Vector2.Lerp(transform.position, calculateDesirePosition(), speed * Time.fixedDeltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, fixedZPosition);
        }
    }

}
