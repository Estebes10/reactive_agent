using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camina : MonoBehaviour {

    private Rigidbody rb;
    public float jumpForce = 4;
    private bool onGround;
    public float jumpSpeed = 5f;
    public float distToGround = 0.5f;

   //Animator controller;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        onGround = true;
        //controller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            Debug.Log("SPACE PRESSDE");
            //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Vector3 jumpVelocity = new Vector3(0, jumpSpeed, 0f);
            rb.velocity = rb.velocity + jumpVelocity;
        }

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 200.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 11.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }
}
