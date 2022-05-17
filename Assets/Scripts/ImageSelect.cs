using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSelect : MonoBehaviour
{
    public GameObject menFirst;
    public GameObject menSecond;
    public GameObject womenFirst;
    public GameObject womenSecond;

    public GameObject robotFirst;
    public GameObject robotSecond;

    private int charInt = 1;
    private int robInt = 1;

    private SpriteRenderer menFirstRen, menSecondRen, womenFirstRen, womenSecondRen;
    private SpriteRenderer robotFirstRen, robotSecondRen;

    private readonly string charSelected = "charSelected";
    private readonly string roboSelected = "roboSelected";

    private Vector3 charPosition;
    private Vector3 charOutside;

    private Vector3 robPosition;
    private Vector3 robOutside;

    private void Awake()
    {
        charPosition = menFirst.transform.position;
        charOutside = menSecond.transform.position;

        robPosition = robotFirst.transform.position;
        robOutside = robotSecond.transform.position;

        menFirstRen = menFirst.GetComponent<SpriteRenderer>();
        menSecondRen = menSecond.GetComponent<SpriteRenderer>();
        womenFirstRen = womenFirst.GetComponent<SpriteRenderer>();
        womenSecondRen = womenSecond.GetComponent<SpriteRenderer>();

        robotFirstRen = robotFirst.GetComponent<SpriteRenderer>();
        robotSecondRen = robotSecond.GetComponent<SpriteRenderer>();


    }

    public void Next()
    {
        switch (charInt)
        {
            case 1:
                PlayerPrefs.SetInt(charSelected, 1);
                menFirstRen.enabled = false;
                menFirst.transform.position = charOutside;
                menSecond.transform.position = charPosition;
                menSecondRen.enabled = true;
                charInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(charSelected, 2);
                menSecondRen.enabled = false;
                menSecond.transform.position = charOutside;
                womenFirst.transform.position = charPosition;
                womenFirstRen.enabled = true;
                charInt++;
                break;
            case 3:
                PlayerPrefs.SetInt(charSelected, 3);
                womenFirstRen.enabled = false;
                womenFirst.transform.position = charOutside;
                womenSecond.transform.position = charPosition;
                womenSecondRen.enabled = true;
                charInt++;
                break;
            case 4:
                PlayerPrefs.SetInt(charSelected, 4);
                womenSecondRen.enabled = false;
                womenSecond.transform.position = charOutside;
                menFirst.transform.position = charPosition;
                menFirstRen.enabled = true;
                charInt++;
                LoopChar();
                break;
            default:
                LoopChar();
                break;
        }
    }

    public void Previous()
    {
        switch (charInt)
        {
            case 4:
                PlayerPrefs.SetInt(charSelected, 4);
                menFirstRen.enabled = false;
                menFirst.transform.position = charOutside;
                womenSecond.transform.position = charPosition;
                womenSecondRen.enabled = true;
                charInt--;
                break;
            case 3:
                PlayerPrefs.SetInt(charSelected, 2);
                womenSecondRen.enabled = false;
                womenSecond.transform.position = charOutside;
                womenFirst.transform.position = charPosition;
                womenFirstRen.enabled = true;
                charInt--;
                break;
            case 2:
                PlayerPrefs.SetInt(charSelected, 3);
                womenFirstRen.enabled = false;
                womenFirst.transform.position = charOutside;
                menSecond.transform.position = charPosition;
                menSecondRen.enabled = true;
                charInt--;
                break;
            case 1:
                PlayerPrefs.SetInt(charSelected, 1);
                menSecondRen.enabled = false;
                menSecond.transform.position = charOutside;
                menFirst.transform.position = charPosition;
                menFirstRen.enabled = true;
                charInt--;
                LoopChar();
                break;
            default:
                LoopChar();
                break;
        }
    }

    private void LoopChar()
    {
        if (charInt >= 4)
            charInt = 1;
        else
            charInt = 4;
    }

    public void RoboNext()
    {
        switch (robInt)
        {
            case 1:
                PlayerPrefs.SetInt(roboSelected, 1);
                robotFirstRen.enabled = false;
                robotFirst.transform.position = robOutside;
                robotSecond.transform.position = robPosition;
                robotSecondRen.enabled = true;
                LoopRobo();
                break;
            case 2:
                PlayerPrefs.SetInt(roboSelected, 2);
                robotSecondRen.enabled = false;
                robotSecond.transform.position = robOutside;
                robotFirst.transform.position = robPosition;
                robotFirstRen.enabled = true;
                LoopRobo();
                break;
            default:
                LoopRobo();
                break;
        }
    }

    public void RoboPrevious()
    {
        switch (robInt)
        {
            case 2:
                PlayerPrefs.SetInt(roboSelected, 1);
                robotFirstRen.enabled = false;
                robotFirst.transform.position = robOutside;
                robotSecond.transform.position = robPosition;
                robotSecondRen.enabled = true;
                LoopRobo();
                break;
            case 1:
                PlayerPrefs.SetInt(roboSelected, 2);
                robotSecondRen.enabled = false;
                robotSecond.transform.position = robOutside;
                robotFirst.transform.position = robPosition;
                robotFirstRen.enabled = true;
                LoopRobo();
                break;
            default:
                LoopRobo();
                break;
        }
    }
    private void LoopRobo()
    {
        if (robInt >= 2)
            robInt = 1;
        else
            robInt = 2;
    }
}
