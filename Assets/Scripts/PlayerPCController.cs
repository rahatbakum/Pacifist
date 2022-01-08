using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPCController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    void Start()
    {

    }

    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        transform.position = transform.position + (transform.right * horizontalAxis + transform.up * verticalAxis) * speed * Time.deltaTime; //Move Player
    }
}
