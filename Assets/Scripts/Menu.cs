using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject blackScreen;
    public GameObject text;
    public GameObject restartButton;
    public GameObject taskList;
    public float fadeRate; //how fast the black screen fades in and out
    private float targetAlpha; //1 = blackscreen visible 0 = blackscreen not visible
    public SpawnManager spawnManager; //for player respawning
    public bool cursorLock = true; //if cursorlock = true you cant see the cursor or move it away from the game window

    public bool gameOver = false;

    private bool taskListOpen = false;
    void Start()
    {
        cursorLock = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) //opening the task menu
        {
            if (!taskListOpen)
            {
                taskList.SetActive(true);
                cursorLock = false;
                taskListOpen = true;
            }
            else if (taskListOpen) //closing task menu
            {
                taskList.SetActive(false);
                cursorLock = true;
                taskListOpen = false;
            }
        }
        
        if (cursorLock == true)
        {
            Cursor.lockState = CursorLockMode.Locked;

        }
        else Cursor.lockState = CursorLockMode.None;

        if (gameOver == true)
        {
            StartCoroutine(FadeIn());
        } 
    }
    public void Reset()
    {
        gameOver = false;
        text.SetActive(false);
        restartButton.SetActive(false);
        StartCoroutine(FadeOut());
    }
    IEnumerator FadeIn()
    {
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
        cursorLock = false;
        spawnManager.RespawnPlayer();
        text.SetActive(true);
        restartButton.SetActive(true);
    }
    IEnumerator FadeOut()
    {
        cursorLock = true;
        blackScreen.SetActive(true);
        targetAlpha = 0f;
        Color curColor = blackScreen.GetComponent<Image>().color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            blackScreen.GetComponent<Image>().color = curColor;

            yield return null;
        }
        
        blackScreen.SetActive(false);
        
    }



}
