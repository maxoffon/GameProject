using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Character()
    {
        SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SetActiveObj()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }

    public void DestroyObj()
    {
        Destroy(GameObject.FindGameObjectWithTag("music"));
    }
}
