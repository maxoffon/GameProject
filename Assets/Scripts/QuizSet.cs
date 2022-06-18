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
        "1.   С вами пытается познакомиться неизвестный пользователь. Какая информация НЕ является конфиденциальной, т.е. той, которой можно поделиться при знакомстве? (1 вариант ответа)",
        "2.	  Как можно достичь высокой информационной безопасности в сети? (2 варианта ответа)",
        "3.   Как приватность в Интернете связана с персональными данными? (1 вариант ответа)",
        "4.	  Какую персональную информацию о себе можно выкладывать в сеть? (1 вариант ответа)",
        "5.   К каким последствиям может привести овершеринг? \n(2 варианта ответа)",
        "6.	  Что такое цифровой след? (1 вариант ответа)"
    };
    private string[][] choices = new string[][]
    {
        new string[] { "A.   ФИО и Возраст", "Б.   Логин и пароль", "В.   Номер телефона", "Г.   Место работы родителей" },
        new string[] { "A.   Использовать всегда одинаковый пароль  ", "Б.   Переходить по непроверенным ссылкам", 
            "В.   Иметь закрытый аккаунт в соц. сетях", "Г.  Использовать сложные логины и пароли" },
        new string[] { "A.   Никак", "Б.   Ваши данные недоступны никому, в том числе и вам", "В.   Ваши данные доступны только с разрешения администратора сети", "Г.   Ваши персональные данные недоступны посторонним" },
        new string[] { "A.  Любую информацию", "Б.  Данные банковских карт", "В.   Свои хобби и достижения", "Г.   Логины и пароли" },
        new string[] { "A.   Никаким", "Б.  Утечка важной информации о вас злоумышленникам", "В.   Понижение уровня приватности", "Г.   Вас заблокируют во всех соц. сетях" },
        new string[] { "A.   Это цифровой отпечаток ноги", "Б.   Б.   Это цифровая информация пользователя, которую нельзя удалить",
            "В.   Это цифровая информация о пользователе, хранящаяся на компьютере",
            "Г.   Это информация о пользователе, которую можно удалить в браузере" }
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
