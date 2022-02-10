using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSound : MonoBehaviour
{
    private static readonly string EffectsPref = "EffectsPref";
    private static readonly string MusicPref = "MusicPref";
    private float MusicFloat, soundEffectsFloat;
    public AudioSource[] soundEffectsAudio;
    
    private void Awake()
    {
        LevelSoundSettings();
    }

    private void LevelSoundSettings()
    {
        MusicFloat = PlayerPrefs.GetFloat(MusicPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(EffectsPref);


        for(int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }
}