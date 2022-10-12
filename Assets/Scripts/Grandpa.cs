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

    private int nextUpdate = 1;

    void Start()
    {
        ResetGrandpa();
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
            grandpaWantsTo = "Walk";
        }
        if (random == 2)
        {
            grandpaWantsTo = "Dance";
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
            random = Random.Range(0, 2);
            grandpaThinking = 0;
            
        }
    }
    public void ResetGrandpa()
    {
        random = 0;
        canThink = true;
    }



}
