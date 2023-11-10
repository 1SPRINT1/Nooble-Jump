using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem instance;

    public bool isSoundOn = true;

    private AudioSource[] audioSources;

    public int SoundS;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        audioSources = FindObjectsOfType<AudioSource>();
        PlayerPrefs.GetInt("Sound", SoundS);
    }

    private void Update()
    {
        audioSources = FindObjectsOfType<AudioSource>();
        if (SoundS == 1)
        {
            isSoundOn = true;
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.mute = isSoundOn;
            }
        }
        if (SoundS == 0)
        {
            isSoundOn = false;
            foreach (AudioSource audioSource in audioSources)
            {
                audioSource.mute = isSoundOn;
            }
        }
        PlayerPrefs.SetInt("Sound", SoundS);
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;

        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.mute = !isSoundOn;
        }
        PlayerPrefs.SetInt("Sound",SoundS);
    }
    public void ToggleON()
    {
        isSoundOn = true;
        SoundS = 1;
        PlayerPrefs.SetInt("Sound", SoundS);
    }
    public void ToggleOff()
    {
        isSoundOn = false;
        SoundS = 0;
        PlayerPrefs.SetInt("Sound", SoundS);
    }
}
