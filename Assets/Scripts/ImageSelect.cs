using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSelect : MonoBehaviour
{
    public Sprite menFirst, menSecond, womenFirst, womenSecond, robotFirst, robotSecond;

    public GameObject currentChar, currentRobot;

    private Sprite[] robots;
    private Sprite[] chars;

    private int charInt = 0;
    private int robInt = 0;
    private static int count = 0;

    private readonly string charSelected = "charSelected";
    private readonly string roboSelected = "roboSelected";

    private void Awake()
    {
        robots = new Sprite[] { robotFirst, robotSecond };
        chars = new Sprite[] { menFirst, menSecond, womenFirst, womenSecond };
        if (PlayerPrefs.HasKey(roboSelected) && PlayerPrefs.HasKey(charSelected) && count != 0)
        {
            robInt = PlayerPrefs.GetInt(roboSelected);
            charInt = PlayerPrefs.GetInt(charSelected);
            currentRobot.GetComponent<Image>().sprite = robots[robInt];
            currentChar.GetComponent<Image>().sprite = chars[charInt];
        }
        else
        {
            currentRobot.GetComponent<Image>().sprite = robots[robInt];
            currentChar.GetComponent<Image>().sprite = chars[charInt];
            PlayerPrefs.SetInt(charSelected, charInt);
            PlayerPrefs.SetInt(roboSelected, robInt);
            count++;
        }
    }

    public void Next()
    {
        charInt = charInt >= 3 ? 0 : charInt + 1;
        currentChar.GetComponent<Image>().sprite = chars[charInt];
        PlayerPrefs.SetInt(charSelected, charInt);
    }

    public void Previous()
    {
        charInt = charInt <= 0 ? 3 : charInt - 1;
        currentChar.GetComponent<Image>().sprite = chars[charInt];
        PlayerPrefs.SetInt(charSelected, charInt);
    }


    public void RoboNext()
    {
        robInt = robInt >= 1 ? 0 : robInt + 1;
        currentRobot.GetComponent<Image>().sprite = robots[robInt];
        PlayerPrefs.SetInt(roboSelected, robInt);
    }

    public void RoboPrevious()
    {
        robInt = robInt <= 0 ? 1 : robInt - 1;
        currentRobot.GetComponent<Image>().sprite = robots[robInt];
        PlayerPrefs.SetInt(roboSelected, robInt);
    }
}
