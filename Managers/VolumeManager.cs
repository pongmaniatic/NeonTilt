using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string backgroundPref = "BackgroundPref";
    private static readonly string soundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectsSlider;
    public float backgroundfloat, soundEffectsfloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            backgroundfloat = 0.25f;
            soundEffectsfloat = 0.75f;
            backgroundSlider.value = backgroundfloat;
            soundEffectsSlider.value = soundEffectsfloat;
            PlayerPrefs.SetFloat(backgroundPref, backgroundfloat);
            PlayerPrefs.SetFloat(soundEffectsPref, soundEffectsfloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
           backgroundfloat =  PlayerPrefs.GetFloat(backgroundPref);
           backgroundSlider.value = backgroundfloat;
           soundEffectsfloat = PlayerPrefs.GetFloat(soundEffectsPref);
           soundEffectsSlider.value = soundEffectsfloat;
        }

    }
    public void SavingSoundSettings()
    {
        PlayerPrefs.SetFloat(backgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(soundEffectsPref, soundEffectsSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if (!inFocus)
        {
            SavingSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    } 

}
