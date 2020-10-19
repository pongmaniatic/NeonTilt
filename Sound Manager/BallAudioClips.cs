using UnityEngine;

public class BallAudioClips : MonoBehaviour
{
    public AudioClip[] blockAudioClips;


    public void PlayJumpAudio()
    {
        SoundManager.PlaySound(blockAudioClips[0], transform.position, new Vector2(2, 2), false);
    }
    public void PlaySmashAudio()
    {
        SoundManager.PlaySound(blockAudioClips[1], transform.position, new Vector2(2, 2), false);
    }

    public void PlayWhateverAudio() { }

}
