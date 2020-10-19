using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allSounds : MonoBehaviour
{
    public static allSounds allSoundsSystem;
    public AudioClip[] sounds;

    void Awake() { allSoundsSystem = this; }

    // Start is called before the first frame update
    void breakSound()
    {
        SoundManager.PlaySound(sounds[0], Vector3.zero, Vector2.one, false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
