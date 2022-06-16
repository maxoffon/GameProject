using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCoroutineGame : MonoBehaviour
{
    public Button Next;
    public Text Object;
    public Image fadein;
    private int countFacts = 0;
    bool ended, started = false;
    private string[] facts = new string[]
   {
        "1. ������������������ � �������� ����������, ����� ������ � ��� ����� ������ ������������ ����.",
        "2. �������������� ������������ � ��� ������� ����������� ������������������, ����������� � ����������� ����������.",
        "3. ����������� � ��������� � ��� ����� �������� �� ���������� � ������� ����� ������������ ����������.",
        "4. ������������ ���������� � ��� �� ����������, �� ������� ����� ����������, ��� ��.",
        "5. ���������� � ���������� �������� ������������ ���������� ������, ��� ������ ��, ������ ������� ������ � �������������� � ������� � �����������.",
        "6. �������� ���� � ��� ����������, ������� �������� � �������� � ���������.",
        "� ������ ����� ���������� ��������� �������� � �����, ��� � ��� ����� ����� ���������. ����� �����, ����� ����������."
   };

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && started) ended = true;
    }

    public void StartThis()
    {
        if (countFacts > 6) fadein.GetComponent<Animator>().enabled = true;
        else
        {
            Next.GetComponent<Button>().interactable = false;
            started = true;
            Object.text = "";
            Object.GetComponent<Text>().enabled = true;
            StartCoroutine(InvokeCoroutine(facts[countFacts]));
            countFacts++;
            PlayerPrefs.SetInt("factsEnd", countFacts);
        }  
    }
    IEnumerator InvokeCoroutine(string text)
    {
        foreach (var letter in text)
        {
            if (!ended)
            {
                Object.text += letter;
                yield return new WaitForSeconds(0.03f);
            }
            else
            {
                Object.text = text;
                started = false;
                ended = false;
                Next.GetComponent<Button>().interactable = true;
                yield break;
            }
        }
        Next.GetComponent<Button>().interactable = true;
        started = false;
        ended = false;
    }
}
