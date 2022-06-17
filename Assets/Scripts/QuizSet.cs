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
        new int[] { 0, 0, 1, 0 },
        new int[] { 0, 1, 0, 0 },
    };
    private string[] questions = new string[]
    {
        "1.  Вам написал незнакомый пользователь, который начал спрашивать вашу личную информацию. О чем можно ему рассказать? Какие данные являются общедоступными? (Один вариант ответа)",
        "2.	Как достичь высокой информационной безопасности в сети? (Два варианта ответа)",
        "3.	Какую информацию о себе можно выкладывать в сеть? (Один вариант ответа)",
        "4.	Что такое цифровой след? (Один вариант ответа)"
    };
    private string[][] choices = new string[][]
    {
        new string[] { "A.   ФИО и Возраст", "Б.   Логин и пароль", "В.   Номер телефона", "Г.   Место работы родителей" },
        new string[] { "A.   Использовать один и тот же пароль на всех сайтах ", "Б.   Отвечать незнакомым пользователям и переходить по их ссылкам", 
            "В.   Иметь закрытый аккаунт в соц сетях, о котором будут знать только друзья", "Г.  Использовать сложные и разные логины и пароли" },
        new string[] { "A.  Любую информацию можно выкладывать в интернете", "Б.  Данные банковских карт", "В.   Свои хобби и интересы", "Г.   Логины и пароли" },
        new string[] { "A.   Это цифровой отпечаток ноги", "Б.   Это цифровая информация о пользователе (какие сайты посещал и с какого IP-адреса), хранящаяся непосредственно в сети и которую невозможно удалить",
            "В.   Это цифровая информация о пользователе (какие сайты посещал и с какого IP-адреса), хранящаяся на компьютере", 
            "Г.   Это цифровая информация о пользователе (какие сайты посещал и с какого IP-адреса), которую пользователь может удалить самостоятельно " }
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
        if (questionNumber > Variants.Count) return;
        else if (questionNumber == Variants.Count) canvas.GetComponent<Animation>().Play("fadeall");
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
