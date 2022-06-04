using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class ColData : MonoBehaviour
{
    [Header("Collisions Controller")]
    public bool  isColliding = false;

    private void Update()
    {
        isColliding = false;
    }
}
