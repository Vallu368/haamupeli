using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingObjective : MonoBehaviour
{
    public TaskList tl;
    public int HowManyTasksForEnding;
    void Start()
    {
        tl = GameObject.Find("GameManager").GetComponent<TaskList>();
    }

    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (tl.tasksCompleted == HowManyTasksForEnding)
            {
                Debug.Log("ending hjere");
            }
            else Debug.Log("no ending here");
        }
    }
}
