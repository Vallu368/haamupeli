using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    private bool hold;
    public KeyCode grabKey;
    public bool canGrab;
    public Animator animator;
    public bool RightHand;

    void Update()
    { 
        if (canGrab) // if canGrab = true you can move arms
        {
            if (Input.GetKey(grabKey)) 
            {
                if (RightHand)
                {
                    animator.SetBool("RightHandUp", true);
                }
                else
                {
                    animator.SetBool("LeftHandUp", true);
                }
                hold = true;
            }
            else
            {
                if (RightHand)
                {
                    animator.SetBool("RightHandUp", false);
                }
                else
                {
                    animator.SetBool("LeftHandUp", false);
                }

                hold = false;
                Destroy(GetComponent<FixedJoint>());
            }
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (hold && col.transform.tag != "Player") //can grab onto anything that isn't tagged Player
        {
            Rigidbody rb = col.transform.GetComponent<Rigidbody>();
            if (rb != null)
            {
                FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
                fj.connectedBody = rb;
            }
            else
            {
                FixedJoint fj = transform.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
            }
        }
    }
}

