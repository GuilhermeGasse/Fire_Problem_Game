using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class Movementplayer : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpheight = 1f;

    public Transform groundcheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;

    Vector3 velocity;
    bool isgrounded;

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckSphere(groundcheck.position, grounddistance, groundmask);

        if (isgrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
