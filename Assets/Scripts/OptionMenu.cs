using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System.Threading;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        audioMixer.GetFloat("volume", out var a);
        PlayerPrefs.SetFloat("volume", a);
    }

    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}