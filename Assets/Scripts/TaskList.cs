using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskList : MonoBehaviour
{
    public List<GameObject> tasks; //list of checkmarks in the task list
    public int tasksCompleted; //amount of tasks completed in total
    public int lastTaskCompleted; //you get this number from the objective script
    public GameObject totalDoneText; //text object for total tasks done
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalDoneText.GetComponent<TMPro.TextMeshProUGUI>().text = tasksCompleted.ToString(); //changes the text to read the number of tasks completed
    }

    public void CompletedTask()
    {
        tasksCompleted++;
        tasks[lastTaskCompleted].SetActive(true); //makes the checkmark for the done task active
    }
}
