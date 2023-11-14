using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    public bool isOnTheGround;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay()
    {
        isOnTheGround = true;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += movement * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && isOnTheGround)
        {
            rb.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;
        }
    }
}
