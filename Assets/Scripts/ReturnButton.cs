using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    public void EscButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
