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
            if (elem.colors.normalColor == elem.colors.pressedColor)
                elem.onClick.Invoke();
        if (Variants[0].colors.normalColor == Variants[0].colors.pressedColor)
            Variants[0].GetComponent<Animator>().enabled = true;
    }
}
