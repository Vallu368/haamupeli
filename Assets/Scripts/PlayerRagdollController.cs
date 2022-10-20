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
    public bool moving = false;
    public Animator anim;

    private int nextUpdate = 1;

    void Start()
    {

    }
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (moving)
        {
            anim.SetBool("walking", true);
        }
        else anim.SetBool("walking", false);
        moving = false;
        if (Input.GetKey(KeyCode.W))
        {
            hips.AddForce(-hips.transform.forward * speed);
            moving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            hips.AddForce(-hips.transform.right * strafeSpeed);
            moving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            hips.AddForce(hips.transform.right * strafeSpeed);
            moving = true;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            hips.AddForce(hips.transform.forward * speed);
            moving = true;
        }
        
       
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                hips.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }
    }
}
