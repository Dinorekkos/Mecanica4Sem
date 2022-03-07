using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    [Header("Physics")]
    [SerializeField] private float MyGravity = 9.81f;
    
    [Header("Player")]
    [SerializeField] private float velocity;
    [SerializeField] private GameObject myGroundCheck;
    
    private PhysicsController MyphysicsController;
    private Vector3 movement;

    private Keyboard keyboard;

    private bool active;
    private bool isGrounded;
    void Start()
    {
        #if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        keyboard = Keyboard.current;
        #endif
        active = true;
        MyphysicsController = new PhysicsController(MyGravity);
    }
    
    void Update()
    {
        if (active)
        {
            if (keyboard != null)
            {
                MovePlayer();
                MyphysicsController.ApplyGravityToObject(movement, this.gameObject, myGroundCheck);
                if(isGrounded)
                {
                    
                }
                else
                {
                    
                }
                
                 
            }
        }
    }

    void MovePlayer(){

        Transform myTransform =  this.gameObject.transform;

        if(keyboard.anyKey.isPressed)
        {
            if(keyboard.sKey.isPressed)
            {
                Debug.Log("MOVE DOWN");
            }
        }

        
    }
    
    
    
    
    
    
}
