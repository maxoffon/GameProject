using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButton : MonoBehaviour
{
    public Button check;
    private static int count;
    private Color trueColor;

    private void Awake()
    {
        var color = Color.white;
        color.a = 1;
        trueColor = color;
    }

    public static void ZeroCount() { count = 0; }

    public void Press()
    {
        if (count < 1)
        {
            check.interactable = true;
            count++;
        }
        var button = GetComponent<Button>();
        var cb = button.colors;
        cb.normalColor = cb.normalColor == cb.pressedColor ? trueColor : cb.pressedColor;
        cb.selectedColor = cb.selectedColor == cb.pressedColor ? trueColor : cb.pressedColor;
        GetComponent<Button>().colors = cb;
    }
}
