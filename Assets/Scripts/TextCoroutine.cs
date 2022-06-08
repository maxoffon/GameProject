using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TextCoroutine : MonoBehaviour
{
    public Button Next;
    public Text Object;
    public Image fadein;
    bool ended, coroutineStarted = false;
    
    private int countTexts = 0;
   
    private string[] texts = new string[]
    {
        "Здравствуй! Меня зовут Макс, и сегодня я буду твоим гидом в мире компьютерной безопасности. Не будем медлить!",
        "Наша первая тема : Кража личных данных, утечка информации. Изучим пару терминов перед практикой."
    };

    private void Update()
    {
        if (Input.GetMouseButton(0)) GetComponent<Animator>().enabled = true;
        if (Input.GetKeyDown(KeyCode.Space) && coroutineStarted) ended = true;
    }

    

    public void StartThis()
    {
        if (countTexts > 1) { fadein.GetComponent<Animator>().enabled = true; return; }
        Next.GetComponent<Button>().interactable = false;
        coroutineStarted = true;
        Object.text = "";
        Object.GetComponent<Text>().enabled = true;
        StartCoroutine(InvokeCoroutine(texts[countTexts]));
        countTexts++;
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
                coroutineStarted = false;
                ended = false;
                Next.GetComponent<Button>().interactable = true;
                yield break;
            }
        }
        Next.GetComponent<Button>().interactable = true;
        coroutineStarted = false;
        ended = false;
    }
}
