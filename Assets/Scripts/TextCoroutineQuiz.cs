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
        StartCoroutine(InvokeCoroutine("����������, �� ������ ���� � �������� ��������� �� " + PlayerPrefs.GetInt("corAns") + " ������(�/��) �� 4. ���� ������, ������ ������ ���� ������ ��� �� ������� � ����. ����� ����� ������ � ����������� :)"));
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
