using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ManageSound : MonoBehaviour
{
    public AudioMixer mixer;
    void Start()
    {
        mixer.SetFloat("volume", PlayerPrefs.GetFloat("volume"));
    }
}
