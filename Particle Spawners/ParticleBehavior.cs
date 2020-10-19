using System.Collections;
using UnityEngine;

public class ParticleBehavior : MonoBehaviour
{
    ParticleSystem particle;
    void Start()
    {
        particle = GetComponent<ParticleSystem>();
        StartCoroutine(ParticleTimer(particle.main.duration));
    }
    IEnumerator ParticleTimer(float lifetime)
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
        yield return null;
    }
}
