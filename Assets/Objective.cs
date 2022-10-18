using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public string myObjectiveName; //name of the gameobject you want to touch this objective marker with
    public GameObject objectiveModel; //model of the gameobject you want to appear
    public int objectiveNumber; //index number for the checkmark list in taskList script
    public bool objectiveUsed = false; //if true touching this objective marker doesnt do anything anymore
    public TaskList tl; 

    private void Start()
    {
        objectiveModel.SetActive(false);
        tl = GameObject.Find("GameManager").GetComponent<TaskList>(); 
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == myObjectiveName) //script only works if the objective touching has the same name as the string myObjectiveName
        {
            if (objectiveUsed == false)
            {
                Debug.Log("BOOP"); 
                Destroy(collision.gameObject); //destroys held gameobject
                objectiveModel.SetActive(true); //sets invisible model of the gameobject visible
                objectiveUsed = true;
                tl.lastTaskCompleted = objectiveNumber; //takes the objectivenumber to the tasklist script for the checkmark activation
                tl.CompletedTask(); 
            }
            else
            {
                Debug.Log("already booped");
            }

        }
    }
}
