using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public GameObject obj;

    public void PlayAnimation()
    {
        obj.GetComponent<Animation>().Play();
    }
}
