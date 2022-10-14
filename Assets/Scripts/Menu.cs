using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject blackScreen;
    public GameObject text;
    public GameObject restartButton;
    public float fadeRate;
    private float targetAlpha;
    public SpawnManager spawnManager;
    public bool cursorLock = true;

    public bool gameOver = false;
    void Start()
    {
        cursorLock = true;
    }

    // Update is called once per frame
    void Update()
    {
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

