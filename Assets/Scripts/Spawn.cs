using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Sprite robotFirst, robotSecond;

    //menFirst, menSecond, womenFirst, womenSecond,

    private SpriteRenderer mainSprite;

    //private readonly string charSelected = "charSelected";
    private readonly string roboSelected = "roboSelected";

    public void Awake()
    {
        mainSprite = this.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        int getChar, getRob;

        //getChar = PlayerPrefs.GetInt(charSelected);
        getRob = PlayerPrefs.GetInt(roboSelected);

        //switch (getChar)
        //{
        //    case 1:
        //        mainSprite.sprite = menSecond;
        //        break;
        //    case 2:
        //        mainSprite.sprite = womenFirst;
        //        break;
        //    case 3:
        //        mainSprite.sprite = womenSecond;
        //        break;
        //    case 4:
        //        mainSprite.sprite = menFirst;
        //        break;
        //    default:
        //        mainSprite.sprite = menFirst;
        //        break;
        //}

        switch (getRob)
        {
            case 1:
                mainSprite.sprite = robotFirst;
                break;
            case 2:
                mainSprite.sprite = robotSecond;
                break;
            default:
                mainSprite.sprite = robotFirst;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
