using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 6;
    private int currentSceneIndex;
    LevelController levelController;
    

    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScene());
        }
    }

    IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ReloadCurrentScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void LoadOptionScreen()
    {
        SceneManager.LoadScene("Option Screen");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
