using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnableAnimator : MonoBehaviour
{
    public GameObject obj;
    public void EnableAnim()
    {
        var a = obj.GetComponent<Animator>();
        a.enabled = !a.enabled;
    }
}
