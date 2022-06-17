using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextCoroutineQuiz : MonoBehaviour
{
    public Button Again;
    public Button ToMenu;
    public Text LocalText;
    bool ended, started = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && started) ended = true;
    }

    public void StartThis()
    {
        Again.GetComponent<Button>().interactable = false;
        ToMenu.GetComponent<Button>().interactable = false;
        started = true;
        LocalText.text = "";
        LocalText.enabled = true;
        StartCoroutine(InvokeCoroutine("ѕоздравл€ю, вы прошли тест и ответили правильно на " + PlayerPrefs.GetInt("corAns") + " вопрос(а/ов) из 4. ≈сли хотите, можете пройти тест заново или же перейти в меню. ∆дите новые уровни в обновлени€х :)"));
    }
    IEnumerator InvokeCoroutine(string text)
    {
        foreach (var letter in text)
        {
            if (!ended)
            {
                LocalText.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
            else
            {
                LocalText.text = text;
                started = false;
                ended = false;
                Again.GetComponent<Button>().interactable = true;
                ToMenu.GetComponent<Button>().interactable = true;
                yield break;
            }
        }
        Again.GetComponent<Button>().interactable = true;
        ToMenu.GetComponent<Button>().interactable = true;
        started = false;
        ended = false;
    }
}
