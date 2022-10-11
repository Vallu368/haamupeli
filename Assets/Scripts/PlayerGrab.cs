using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public Animator anim;
    public GameObject grabbedObj;
    public Rigidbody rb;
    public int isLeftorRight;
    public bool alreadyGrabbing = false;
    public bool grabbing;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!grabbing)
        {
            
            if (grabbedObj != null)
            {
                Destroy(grabbedObj.GetComponent<FixedJoint>());
            }

        }
        if (Input.GetMouseButtonDown(isLeftorRight))
        {
            if(isLeftorRight == 0)
            {
                anim.SetBool("LeftHandUp", true);
            }
            if(isLeftorRight == 1)
            {
                anim.SetBool("RightHandUp", true);
            }
            grabbing = true;
            
        } else if (Input.GetMouseButtonUp(isLeftorRight))
        {
            grabbing = false;
            if (isLeftorRight == 0)
            {
                anim.SetBool("LeftHandUp", false);
            }
            if (isLeftorRight == 1)
            {
                anim.SetBool("RightHandUp", false);
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Grabbable"))
        {
            if (grabbing)
            {
                Debug.Log("touched grabbable obj");
                grabbedObj = other.gameObject;
                FixedJoint fj = grabbedObj.AddComponent<FixedJoint>();
                fj.connectedBody = rb;
                fj.breakForce = 9001;
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        grabbedObj = null;
    }
}
