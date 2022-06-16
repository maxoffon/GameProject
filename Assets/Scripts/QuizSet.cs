using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizSet : MonoBehaviour
{
    public Text Question;
    public List<Button> Variants;
    public Button Check;

    public void CheckAnswer()
    {
        foreach (var elem in Variants)
        {
            if (elem.colors.normalColor == elem.colors.pressedColor || elem.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "correctAnswer")
            {
                elem.onClick.Invoke();
                elem.GetComponent<Animator>().enabled = true;
            }
            elem.enabled = false;
        }    
    }
}
