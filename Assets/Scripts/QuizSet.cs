using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizSet : MonoBehaviour
{
    public Canvas canvas;
    public Text Question;
    public List<Button> Variants;
    public Button Check;
    public Button Next;
    private int questionNumber = -1;
    private Color color;
    private int correctAns = 0;
    private int[][] answers = new int[][] 
    { 
        new int[] { 1, 0, 0, 0 },
        new int[] { 0, 0, 1, 1 },
        new int[] { 0, 0, 0, 1 },
        new int[] { 0, 0, 1, 0 },
        new int[] { 0, 1, 1, 0 },
        new int[] { 0, 1, 0, 0 },
    };
    private string[] questions = new string[]
    {
        "1.   � ���� �������� ������������� ����������� ������������. ����� ���������� �� �������� ����������������, �.�. ���, ������� ����� ���������� ��� ����������? (1 ������� ������)",
        "2.	  ��� ����� ������� ������� �������������� ������������ � ����? (2 �������� ������)",
        "3.   ��� ����������� � ��������� ������� � ������������� �������? (1 ������� ������)",
        "4.	  ����� ������������ ���������� � ���� ����� ����������� � ����? (1 ������� ������)",
        "5.   � ����� ������������ ����� �������� ����������? \n(2 �������� ������)",
        "6.	  ��� ����� �������� ����? (1 ������� ������)"
    };
    private string[][] choices = new string[][]
    {
        new string[] { "A.   ��� � �������", "�.   ����� � ������", "�.   ����� ��������", "�.   ����� ������ ���������" },
        new string[] { "A.   ������������ ������ ���������� ������  ", "�.   ���������� �� ������������� �������", 
            "�.   ����� �������� ������� � ���. �����", "�.  ������������ ������� ������ � ������" },
        new string[] { "A.   �����", "�.   ���� ������ ���������� ������, � ��� ����� � ���", "�.   ���� ������ �������� ������ � ���������� �������������� ����", "�.   ���� ������������ ������ ���������� �����������" },
        new string[] { "A.  ����� ����������", "�.  ������ ���������� ����", "�.   ���� ����� � ����������", "�.   ������ � ������" },
        new string[] { "A.   �������", "�.  ������ ������ ���������� � ��� ���������������", "�.   ��������� ������ �����������", "�.   ��� ����������� �� ���� ���. �����" },
        new string[] { "A.   ��� �������� ��������� ����", "�.   �.   ��� �������� ���������� ������������, ������� ������ �������",
            "�.   ��� �������� ���������� � ������������, ���������� �� ����������",
            "�.   ��� ���������� � ������������, ������� ����� ������� � ��������" }
    };

    private void Awake()
    {
        color = Variants[0].GetComponent<Image>().color;
        color.a = 1;
        PressButton.ZeroCount();
        PlayerPrefs.SetInt("corAns", correctAns);
        ChangeQuestion();
    }

    public void CheckAnswer()
    {
        Check.gameObject.SetActive(false);
        Next.gameObject.SetActive(true);
        var correct = 0;
        var incorrect = 0;
        var totalCorrect = 0;
        for (var i = 0; i < Variants.Count; i++)
        {
            if (Variants[i].colors.normalColor == Variants[i].colors.pressedColor)
            {
                Variants[i].onClick.Invoke();
                Variants[i].GetComponent<Animation>().Play(answers[questionNumber][i] == 1 ? "correctAnswer" : "incorrectAnswer");
                if (answers[questionNumber][i] == 1)
                {
                    correct++;
                    totalCorrect++;
                }
                else incorrect++;
            }
            else if (answers[questionNumber][i] == 1)
            {
                Variants[i].GetComponent<Animation>().Play("correctAnswer");
                totalCorrect++;
            }
            Variants[i].enabled = false;
        }
        if (correct == totalCorrect && incorrect == 0) correctAns++;
        PlayerPrefs.SetInt("corAns", correctAns);
    }

    public void ChangeQuestion()
    {
        questionNumber++;
        if (questionNumber > questions.Length) return;
        else if (questionNumber == questions.Length) canvas.GetComponent<Animation>().Play("fadeall");
        else
        {
            PressButton.ZeroCount();
            Check.gameObject.SetActive(true);
            Check.interactable = false;
            Next.gameObject.SetActive(false);
            Question.text = questions[questionNumber];
            for (var i = 0; i < Variants.Count; i++)
            {
                Variants[i].GetComponentInChildren<Text>().text = choices[questionNumber][i];
                Variants[i].GetComponent<Image>().color = color;
                Variants[i].enabled = true;
            }
        } 
    }
}
