using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager s;

    public List<ActivePostEffect> activePostEffects;
    public List<GameObject> entities;
    public ActivePostEffect chromaticHitEffect;

    void Awake()
    {
        s = this;
    }
}
