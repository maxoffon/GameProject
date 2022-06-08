using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string MuterState = "MuterState";
    private int firstPlayint;
    public Slider musicSlider;
    public AudioSource musicAudio;
    public Toggle muter;

    private void Awake()
    {
        firstPlayint = PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayint == 0)
        {
            musicSlider.value = 0.5f;
            muter.isOn = true;
            PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
            PlayerPrefs.SetInt(FirstPlay, -1);
            PlayerPrefs.SetInt(MuterState, 1);
        }
        else
        {
            muter.isOn = PlayerPrefs.GetInt(MuterState) != 0;
            musicSlider.value = muter.isOn ? PlayerPrefs.GetFloat(MusicPref) : 0;
            musicSlider.enabled = muter.isOn;
        }
    }

    public void SaveSoundSettings()
    {
        if (muter.isOn) PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
        var a = muter.isOn ? 1 : 0;
        PlayerPrefs.SetInt(MuterState, a);
    }

    public void UpdateSound()
    {
        musicAudio.volume = musicSlider.value;
        if (muter.isOn) PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
    }

    public void Sound()
    {
        if (!muter.isOn)
        {
            musicSlider.value = 0f;
            PlayerPrefs.SetInt(MuterState, 0);
            musicSlider.enabled = false;
        }
        else
        {
            musicSlider.value = PlayerPrefs.GetFloat(MusicPref);
            PlayerPrefs.SetInt(MuterState, 1);
            musicSlider.enabled = true;
        }
    }
}
