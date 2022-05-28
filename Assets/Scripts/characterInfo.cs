using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterInfo : MonoBehaviour
{
    public Sprite robot1;
    public Sprite robot2;
    public GameObject currentRobot;
    void Start()
    {
        var a = new Sprite[] { robot1, robot2 };
        currentRobot.GetComponent<Image>().sprite = PlayerPrefs.HasKey("roboSelected") ? a[PlayerPrefs.GetInt("roboSelected")] : currentRobot.GetComponent<Image>().sprite;
    }

}
