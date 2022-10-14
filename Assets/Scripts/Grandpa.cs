using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandpa : MonoBehaviour
{
    public string grandpaWantsTo = "Null"; //what grandpa wants to do
    private GrandpaMovement movement;
    private FieldOfView fov;
    public int grandpaThinking; //cooldown for grandpa
    public bool action;
    public int random;
    public bool canThink;
    public Animator anim;
    public bool hasTurned;
    private int nextUpdate = 1;

    void Start()
    {
        movement = this.GetComponent<GrandpaMovement>();
        fov = this.GetComponent<FieldOfView>();
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextUpdate) //for cooldown
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }
        if (random <= 1)
        {
            grandpaWantsTo = "Idle";
        }
        if (random == 1)
        {
            if (hasTurned)
            {
                grandpaWantsTo = "Walk";
            }
            else random = 4;
        }
        if (random == 2)
        {
            grandpaWantsTo = "Dance";
        }
        if (random == 4)
        {
            grandpaWantsTo = "Turn";
        }
        if (grandpaThinking >= 5)
        {
            action = true;
        }
        else action = false;

        if (grandpaWantsTo == "Idle")
        {
            anim.SetBool("isWalking", false);
        }

        if (grandpaWantsTo == "Walk")
        {
            anim.SetBool("isWalking", true);
            movement.moving = true;
            canThink = false;
        }

        
        
    }
    void UpdateEverySecond()
    {
        if (!action && canThink)
        {
            grandpaThinking++;
        }
        if (action)
        {
            random = Random.Range(1, 2);
            grandpaThinking = 0;
            
        }
    }
    public void ResetGrandpa()
    {
        //resetting grandpa
        random = 0;
        hasTurned = false;
        canThink = true;
    }



}
