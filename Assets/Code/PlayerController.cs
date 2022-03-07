using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    [Header("Physics")]
    [SerializeField] private float MyGravity = 9.81f;
    
    [Header("Player")]
    [SerializeField] private float velocity;
    
    
    private PhysicsController MyphysicsController;
    private Vector2 movement;
    
    void Start()
    {
        MyphysicsController = new PhysicsController(MyGravity);
    }
    
    void Update()
    {
        MyphysicsController.ApplyGravityToObject(this.gameObject);
    }
    
    
    
    
    
    
}
