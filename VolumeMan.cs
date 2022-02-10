using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeMan : MonoBehaviour
{
   
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string EffectsPref = "EffectsPref";
    private int firstPlayInt;
    public Slider musicSlider, soundEffectsSlider;
    private float MusicFloat, soundEffectsFloat;
    public AudioSource musicAudio;
    public AudioSource[] soundEffectsAudio;
    // Start is called before the first frame update
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        
        if(firstPlayInt == 0)
        {
            MusicFloat = 0.25f;
            soundEffectsFloat = 0.75f;
            musicSlider.value = MusicFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(MusicPref, MusicFloat);
            PlayerPrefs.SetFloat(EffectsPref, soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            MusicFloat = PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value = MusicFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(EffectsPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }
        public void SaveSoundSettings()
        {
            PlayerPrefs.SetFloat(MusicPref, musicSlider.value);
            PlayerPrefs.SetFloat(EffectsPref, soundEffectsSlider.value);
        }

        void OnApplicationFocus(bool inFocus)
        {
            if(!inFocus)
            SaveSoundSettings();
        }
    
    public void UpdateSound()
    {
        musicAudio.volume = musicSlider.value;
        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    }
}
