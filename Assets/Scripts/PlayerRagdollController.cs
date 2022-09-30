using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdollController : MonoBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;

    public Rigidbody hips;
    public bool isGrounded;
    void Start()
    {
        hips = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("moving forward");
            hips.AddForce(hips.transform.forward * speed);
        }
    }
}
