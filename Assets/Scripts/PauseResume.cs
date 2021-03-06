using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseResume : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject pauseMenu;
    bool pause;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            pause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pause) Continue();
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        optionMenu.SetActive(false);
        pause = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
