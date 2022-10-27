using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRagdollController : MonoBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;
    public AudioSource jumpSound;

    public Rigidbody hips;
    public bool isGrounded;
    public bool moving = false;
    public Animator anim;
    public bool canJump = true;

    private int nextUpdate = 1;
    private int i = 0;
    private int maxSpeed = 4;
    public float speedWhenJumping;
    private float speedy;
    void Start()
    {
        speedy = speed;
    }
    private void Update()
    {
       // Debug.Log(hips.velocity.magnitude);
        if (i >= 1)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }
        if (!isGrounded)
        {

            speed = speedWhenJumping;
        }
        else speed = speedy;
    }

    void UpdateEverySecond()
    {
        i++;
    }
    void FixedUpdate()
    {
        if (hips.velocity.magnitude > maxSpeed)
        {
            hips.velocity = hips.velocity.normalized * maxSpeed;
        }
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
        
       
        
        if (Input.GetKey(KeyCode.Space)  && canJump)
        {
            if (isGrounded) 
            {
                jumpSound.Play();
                hips.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
                canJump = false;
                i = 0;
            }
        }
    }
}
