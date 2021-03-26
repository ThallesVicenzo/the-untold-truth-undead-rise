using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public Canvas canvas;
    public void NewGame()
    {
        SceneManager.LoadScene("Level0");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GetComponent<CanvasGroup>().alpha = 0;
        canvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
