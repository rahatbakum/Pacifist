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
    //[SerializeField] private float outrunCoefficient = 2f;

    private float fixedZPosition;
    private Rigidbody2D targetRigidBody;

    void Start()
    {
        if (isSaveCurrentOffsetOnStart)
        {
            offset = transform.position - targetObject.position;
        }

        fixedZPosition = transform.position.z;

        targetRigidBody = targetObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveCamera();
    }

    Vector3 calculateDesirePosition()
    {
        Vector3 ans = targetObject.position + offset;
        // if (targetRigidBody)
        // {
        //     Vector3 velocityOffset = new Vector3(targetRigidBody.velocity.x, targetRigidBody.velocity.y, 0f);
        //     ans = ans + velocityOffset * outrunCoefficient * Time.fixedDeltaTime;
        // }
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
