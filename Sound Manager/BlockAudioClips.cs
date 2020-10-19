using UnityEngine;

public class BlockAudioClips : MonoBehaviour
{
    public AudioClip[] blockAudioClips;


    public void PlayBounceAudio()
    {
        Debug.Log("Lmao impact Sound");
        SoundManager.PlaySound(blockAudioClips[0], transform.position, new Vector2(2, 2), false);
    }
    public void PlayDestuctionAudio()
    {
        Debug.Log("Lmao death Sound");
        SoundManager.PlaySound(blockAudioClips[1], transform.position, new Vector2(2, 2), false);
    }
}
