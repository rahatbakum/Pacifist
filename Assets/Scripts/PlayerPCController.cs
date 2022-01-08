using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPCController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Rigidbody2D thisRigidBody;

    void Start()
    {
        thisRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        thisRigidBody.velocity = new Vector2(horizontalAxis * speed, verticalAxis * speed);
    }
}
