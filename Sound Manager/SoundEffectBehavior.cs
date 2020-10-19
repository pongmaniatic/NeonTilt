using UnityEngine;

public class SoundEffectBehavior : MonoBehaviour
{
    [HideInInspector]
    public AudioSource audioSource;
    public Vector2 pitchShift;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(pitchShift.x, pitchShift.y);
    }

    private void LateUpdate()
    {
        if (!audioSource.isPlaying)
            Destroy(gameObject);
    }
}
