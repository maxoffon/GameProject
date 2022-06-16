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
        "1. Конфиденциальность — свойство информации, когда доступ к ней имеют только определенные лица.",
        "2. Информационная безопасность — это процесс обеспечения конфиденциальности, целостности и доступности информации.",
        "3. Приватность в Интернете — это право человека на сохранение в секрете своей персональной информации.",
        "4. Персональная информация — это та информация, по которой можно определить, кто вы.",
        "5. Овершеринг — стремление человека рассказывать окружающим больше, чем стоило бы, заходя слишком далеко с откровенностью и забывая о приватности.",
        "6. Цифровой след — вся информация, которая остается о человеке в Интернете.",
        "А теперь давай рассмотрим некоторые ситуации и поймём, как в них лучше всего поступать. Нажми Далее, чтобы продолжить."
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
