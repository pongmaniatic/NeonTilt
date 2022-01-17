using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obst_Propeller : MonoBehaviour
{
    [Range(-20f,20f)] public float rotateSpeed;
    private void FixedUpdate()
    {
        transform.Rotate(0f,rotateSpeed,0f);
    }

    
}
