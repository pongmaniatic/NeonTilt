using UnityEngine;
using UnityEngine.UI;

public class UltimateVolumeManager : MonoBehaviour
{
    public static UltimateVolumeManager ultimateVolumeManager;
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string backgroundPref = "BackgroundPref";
    private static readonly string soundEffectsPref = "SoundEffectsPref";
    private int firstPlayInt;
    public Slider backgroundSlider1, soundEffectsSlider1;
    public Slider backgroundSlider2, soundEffectsSlider2;
    public float backgroundfloat, soundEffectsfloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    public GameObject SliderHolder1;
    public GameObject SliderHolder2;

    void Start()
    {
        ultimateVolumeManager = this;
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
        if (firstPlayInt == 0)
        {
            backgroundfloat = 0.75f;
            soundEffectsfloat = 0.75f;
            backgroundSlider1.value = backgroundfloat;
            soundEffectsSlider1.value = soundEffectsfloat;
            backgroundSlider2.value = backgroundfloat;
            soundEffectsSlider2.value = soundEffectsfloat;
            PlayerPrefs.SetFloat(backgroundPref, backgroundfloat);
            PlayerPrefs.SetFloat(soundEffectsPref, soundEffectsfloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            backgroundfloat = PlayerPrefs.GetFloat(backgroundPref);
            backgroundSlider1.value = backgroundfloat;
            backgroundSlider2.value = backgroundfloat;
            soundEffectsfloat = PlayerPrefs.GetFloat(soundEffectsPref);
            soundEffectsSlider1.value = soundEffectsfloat;
            soundEffectsSlider2.value = soundEffectsfloat;
        }

    }
    public void SavingSoundSettings()
    {
        if (SliderHolder1.activeInHierarchy == true)
        {
            PlayerPrefs.SetFloat(backgroundPref, backgroundSlider1.value);
            PlayerPrefs.SetFloat(soundEffectsPref, soundEffectsSlider1.value);
        }
        if (SliderHolder2.activeInHierarchy == true)
        {
            PlayerPrefs.SetFloat(backgroundPref, backgroundSlider2.value);
            PlayerPrefs.SetFloat(soundEffectsPref, soundEffectsSlider2.value);
        }
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
        SavingSoundSettings();
        backgroundAudio.volume = backgroundSlider1.value;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider1.value;
        }
    }
    private void Update()
    {
        UpdateSound();
    }
}
