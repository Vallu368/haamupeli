using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaMovement : MonoBehaviour
{
    public int random;
    public Transform[] waypoints; //waypoints where grandpa will walk
    public int speed; //grandpa walking speed
    public bool atPoint; //checks if grandpa is at a waypoint
    public Grandpa grandpa;
    public FieldOfView fov;

    private int waypointIndex; //which waypoint in the list
    private float dist; //distance from waypoint
    private int nextUpdate = 1;

    public bool moving;
    public int playerInSight;
    public bool playerDetected = false;
    public AudioSource death;

    private void Start()
    {
        
        waypointIndex = 0;
        transform.LookAt(waypoints[waypointIndex].position);
        grandpa = this.GetComponent<Grandpa>();
        fov = this.GetComponent<FieldOfView>();
        
    }

    private void Update()
    {
        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            UpdateEverySecond();
        }
        dist = Vector3.Distance(transform.position, waypoints[waypointIndex].position);
        if (dist < 1f) //if at waypoint
        {
            atPoint = true;
            Randomize();
            grandpa.ResetGrandpa();
            moving = false;
        }
        else atPoint = false;
        if (moving)
        {
            Patrol();
        }
        if (!fov.canSeePlayer)
        {
            playerInSight = 0;
        }
        if (playerInSight >= 5)
        {
            playerDetected = true;
        }
        if (fov.canSeePlayer && playerDetected) //game over if he sees player for 5 seconds
        {
            moving = false;
            grandpa.ResetGrandpa();
            grandpa.canThink = false;
            transform.LookAt(fov.player.transform);
            death.Play();
            Debug.Log("deth");
            
        }
        if (Input.GetKey(KeyCode.H))
        {
            Debug.Log("yoda");
            death.Play();
        }

    }
    
    void UpdateEverySecond()
    {
        if (fov.canSeePlayer)
        {
            playerInSight++;
        }
    }
    private void Patrol() //walks to next waypoint
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
    
    void Randomize() //picks a random number from 0 to 10, if above 5, walks to next waypoint, if less then to the last one
    {
        random = Random.Range(0, 10);
        if (random >= 5)
        {
            IncreaseIndex();
        }
        else DecreaseIndex();
    }

    void IncreaseIndex() 
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }
    void DecreaseIndex()
    {
        waypointIndex = waypointIndex - 1;
        if (waypointIndex <= 0)
        {
            waypointIndex = 0;
        }
        transform.LookAt(waypoints[waypointIndex].position);
    }

}
