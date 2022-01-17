using UnityEngine;

public class AudioSetting : MonoBehaviour
{
    private static readonly string backgroundPref = "BackgroundPref";
    private static readonly string soundEffectsPref = "SoundEffectsPref";
    public float backgroundfloat, soundEffectsfloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void ContinueSettings()
    {
        backgroundfloat = PlayerPrefs.GetFloat(backgroundPref);
        soundEffectsfloat = PlayerPrefs.GetFloat(soundEffectsPref);
        backgroundAudio.volume = backgroundfloat;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsfloat;
        }
    }
}
