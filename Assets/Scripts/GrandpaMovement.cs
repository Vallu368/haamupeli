using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GrandpaMovement : MonoBehaviour
{
    public int random;
    public Transform[] waypoints; //waypoints where grandpa will walk
    public int speed; //grandpa walking speed
    public bool atPoint; //checks if grandpa is at a waypoint
    public Grandpa grandpa;
    public FieldOfView fov;
    public SpawnManager spawnManager;
    public Menu menu;

    public int waypointIndex; //which waypoint in the list
    private float dist; //distance from waypoint
    private int nextUpdate = 1;

    public bool moving;
    public int playerInSight;
    public bool playerDetected = false;
    public AudioSource death;
    public bool canTurn = false;
    public GameObject inSight;
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
            canTurn = false;
            
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
        if (playerInSight == 0)
        {
            inSight.SetActive(false);
        }
        if (playerInSight != 0)
        {
            inSight.SetActive(true);
        }
        if (playerInSight >= 3)
        {
            playerDetected = true;
        }
        if (fov.canSeePlayer && playerDetected) //game over if he sees player for 5 seconds
        {
            moving = false;
            grandpa.ResetGrandpa();
            grandpa.canThink = false;
            transform.LookAt(fov.player.transform);
            menu.gameOver = true;




        }
        else menu.gameOver = false;
        if (Input.GetKey(KeyCode.H))
        {
            Debug.Log("yoda");
            death.Play();
        }
        if (grandpa.grandpaWantsTo == "Turn")
        {
            
            var targetRotation = Quaternion.LookRotation(waypoints[waypointIndex].transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            if (transform.rotation == targetRotation)
            {
                grandpa.hasTurned = true;
            }
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
        canTurn = false;

    }
    
    void Randomize() //picks a random number from 0 to 10, if above 5, walks to next waypoint, if less then to the last one
    {
        random = Random.Range(0, 10);
        if (random >= 2)
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
        


    }
    void DecreaseIndex()
    {
        waypointIndex = waypointIndex - 1;
        if (waypointIndex <= 0)
        {
            waypointIndex = 0;
        }
    }

}
