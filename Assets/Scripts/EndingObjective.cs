using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingObjective : MonoBehaviour
{
    public TaskList tl;
    public PlayerRagdollController playerMov;
    public int HowManyTasksForEnding;
    public GameObject blackScreen;
    public float fadeRate;
    private float targetAlpha;
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
                StartCoroutine(Ending());
               // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else Debug.Log("no ending here");
        }
    }

    IEnumerator Ending()
    {
        Debug.Log("boopis");
        playerMov.enabled = false;
        Debug.Log("fading to black");
        blackScreen.SetActive(true);
        targetAlpha = 1.0f;
        Color curColor = blackScreen.GetComponent<Image>().color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            blackScreen.GetComponent<Image>().color = curColor;

            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
