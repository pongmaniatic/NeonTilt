using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject soundEffectPrefab;
    public static SoundManager soundManager;

    void Awake(){soundManager = this;}
    public static void PlaySound(AudioClip clip, Vector3 pos, Vector2 pitchShift, bool loop)
    {
        //GameObject soundEffect = new GameObject();
        //soundEffect = Instantiate(soundEffect, pos, Quaternion.identity);
        GameObject soundEffect = Instantiate(soundManager.soundEffectPrefab, pos, Quaternion.identity);
        //AudioSource audioSource = soundEffect.AddComponent(typeof(AudioSource)) as AudioSource;
        AudioSource audioSource = soundEffect.GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.volume = UltimateVolumeManager.ultimateVolumeManager.soundEffectsfloat;
        //SoundEffectBehavior soundScript = soundEffect.AddComponent(typeof(SoundEffectBehavior)) as SoundEffectBehavior;
        SoundEffectBehavior soundScript = soundEffect.GetComponent<SoundEffectBehavior>();
        soundScript.pitchShift = pitchShift;
        audioSource.Play();
    }
    public static void PlaySound(AudioClip clip, Vector3 pos, Vector2 pitchShift){PlaySound(clip, pos, pitchShift, false);}
    public static void PlaySound(AudioClip clip, Vector3 pos){PlaySound(clip, pos, Vector2.zero, false);}
}
