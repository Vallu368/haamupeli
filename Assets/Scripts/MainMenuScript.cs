using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private float targetAlpha;
    public float fadeRate = 5f;
    public GameObject mainMenu;
    public GameObject blackScreen;
    public GameObject cutsceneImage1;
    public GameObject cutscene1Text;
    // Start is called before the first frame update
    void Start()
    {
        blackScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeOutUI()
    {
        StartCoroutine(FadeMainMenuToBlack());
        mainMenu.SetActive(false);
        
    }

    void EndGame()
    {
        Application.Quit();
    }
    IEnumerator FadeMainMenuToBlack()
    {
        blackScreen.SetActive(true);

        Debug.Log("fading to black");
        targetAlpha = 1.0f;
        Color curColor = blackScreen.GetComponent<Image>().color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            blackScreen
                .GetComponent<Image>().color = curColor;

            yield return null;
        }
        StartCoroutine(FadeInCutscene1());
    }
    IEnumerator FadeInCutscene1()
    {
        cutsceneImage1.SetActive(true);

        Debug.Log("cutsceneimg1");
        fadeRate = 3f;
        targetAlpha = 1.0f;
        Color curColor = cutsceneImage1.GetComponent<Image>().color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, fadeRate * Time.deltaTime);
            cutsceneImage1
                .GetComponent<Image>().color = curColor;

            yield return null;
        }
        cutscene1Text.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
