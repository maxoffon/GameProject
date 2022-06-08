using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangePictures : MonoBehaviour
{
    public Image Pic1, Pic2;
    private Sprite[] arr;
    private int first = 0;
    private int second = 1;
    public Sprite pic1, pic2, pic3, pic4, pic5, pic6;

    public void Start()
    {
        arr = new Sprite[] { pic1, pic2, pic3, pic4, pic5, pic6 };
    }

    public void ChangePics()
    {
        if (PlayerPrefs.GetInt("factsEnd") > 6) return;
        first += 2;
        first %= 6;
        Pic1.sprite = arr[first];
        second += 2;
        second %= 6;
        Pic2.sprite = arr[second];
    }
}
