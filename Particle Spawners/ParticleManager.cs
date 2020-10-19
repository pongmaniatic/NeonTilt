using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager particleManager;
    private void Awake(){ particleManager = this;}
    public static void SpawnParticle(GameObject _particle, Vector3 pos, Gradient color, Vector3 force, float forceMultiplier)
    {
        GameObject particle = Instantiate(_particle, pos, Quaternion.identity);
        ParticleBehavior particleBehavior = particle.AddComponent(typeof(ParticleBehavior)) as ParticleBehavior;
        if (color != null)
        {
            ParticleSystem.MainModule settings = particle.GetComponent<ParticleSystem>().main;
            ParticleSystem.MinMaxGradient grad = new ParticleSystem.MinMaxGradient(color);
            grad.mode = ParticleSystemGradientMode.RandomColor;
            // then set this grad variable to some particle module
            settings.startColor = grad;
        }
        if (particle.TryGetComponent(out Rigidbody rb))
            rb.AddForce(force * forceMultiplier, ForceMode.Impulse);
    }
    public static void SpawnParticle(GameObject _particle, Vector3 pos, Gradient color){SpawnParticle(_particle, pos, color, Vector3.zero, 0);}
    public static void SpawnParticle(GameObject _particle, Vector3 pos){SpawnParticle(_particle, pos, null);}


}
