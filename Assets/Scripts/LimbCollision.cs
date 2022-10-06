using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour //scripti joka osaan, is grounded = true aina kun koskee johonkin mill‰‰n
{
    public PlayerRagdollController playerController;

        private void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerRagdollController>().GetComponent<PlayerRagdollController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerController.isGrounded = true;
    }
}
