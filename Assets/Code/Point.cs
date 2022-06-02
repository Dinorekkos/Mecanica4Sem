using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private MeshRenderer _renderer;
    private Collider _collider;
    public bool isActive = false;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponent<MeshRenderer>();
        
        HandleState(true);
    }

    public void MovePoint(Vector3 placeToMove)
    { 
        transform.position = placeToMove;
    }

    public void HandleState(bool active)
    {
        _collider.enabled = active;
        _renderer.enabled = active;
        
    }
    
    
    
}
