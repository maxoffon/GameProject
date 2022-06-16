using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButton : MonoBehaviour
{
    private Color trueColor;

    private void Awake()
    {
        var color = Color.white;
        color.a = 1;
        trueColor = color;
    }
    public void Press()
    {
        var button = GetComponent<Button>();
        var cb = button.colors;
        cb.normalColor = cb.normalColor == cb.pressedColor ? trueColor : cb.pressedColor;
        cb.selectedColor = cb.selectedColor == cb.pressedColor ? trueColor : cb.pressedColor;
        GetComponent<Button>().colors = cb;
    }
}
