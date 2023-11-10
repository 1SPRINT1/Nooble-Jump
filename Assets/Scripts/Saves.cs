using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saves : MonoBehaviour
{
    public float BestScore;
    public int SoundSys;

    private void Start()
    {
        BestScore = PlayerPrefs.GetFloat("BestScore", BestScore);
        SoundSys = PlayerPrefs.GetInt("Sound", SoundSys);
    }
    private void Update()
    {
        BestScore = PlayerPrefs.GetFloat("BestScore", BestScore);
        SoundSys = PlayerPrefs.GetInt("Sound", SoundSys);
    }
}
