using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_ActivePostEffect : Entity
{
    ActivePostEffect postEffect;
    public override void Start()
    {
        postEffect = GetComponent<ActivePostEffect>();
        EntityManager.s.activePostEffects.Add(postEffect);
    }

    public override void OnDestroy()
    {
        EntityManager.s.activePostEffects.Remove(postEffect);
    }
}
