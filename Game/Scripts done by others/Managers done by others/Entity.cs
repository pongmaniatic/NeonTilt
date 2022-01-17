using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public virtual void Start()
    {
        EntityManager.s.entities.Add(gameObject);
    }

    public virtual void OnDestroy()
    {
        EntityManager.s.entities.Remove(gameObject);
    }
}
