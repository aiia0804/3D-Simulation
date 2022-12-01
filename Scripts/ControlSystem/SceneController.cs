using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    int currentSceneIndex;
    public void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void loadNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void replayTheScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void backToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void loadOptionScene()
    {
        SceneManager.LoadScene("Option Screen");
    }

    public void loadGameOverScene()
    {
        SceneManager.LoadScene("Game Over Screen");
    }

    public void quitgame()
    {
        Application.Quit();
    }
}
