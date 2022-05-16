using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class TextCoroutine : MonoBehaviour
{
    public Button Next;
    public Text Object;
    private string text;
    bool ended, coroutineStarted = false;

    private void Update()
    {
        if (Input.GetMouseButton(0)) GetComponent<Animator>().enabled = true;
        if (Input.GetKeyDown(KeyCode.Space) && coroutineStarted) ended = true;
    }

    public void UpdateAndStart(Text obj)
    {
        if (obj == Object) return;
        Destroy(Object);
        Object = obj;
        StartThis();
    }

    public void StartThis()
    {
        Next.GetComponent<Button>().interactable = false;
        coroutineStarted = true;
        text = Object.text;
        Object.text = "";
        Object.GetComponent<Text>().enabled = true;
        StartCoroutine(InvokeCoroutine());
    }

    IEnumerator InvokeCoroutine()
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
