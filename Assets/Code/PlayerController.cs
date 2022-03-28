using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = System.Numerics.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [Header("Physics")] 
    [SerializeField] private float MyGravity = 9.81f;
    
    [Header("Player")] 

    [SerializeField] private float velocityMovement = 1;
    [SerializeField] private float speedVelocity = 1;
    [SerializeField] private float maxHighJump = 5;
    public bool isGrounded;
    [SerializeField] private bool resetPlayer;

    [SerializeField] private GameObject myGroundCheck;

    private PhysicsController MyphysicsController;

    private Vector3 movement;
    private Vector3 inicialPos;
    private Vector3 myPosition;

    private Keyboard keyboard;

    private bool active;
   
    private bool canJump;

    
    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        keyboard = Keyboard.current;
#endif
        active = true;
        // MyphysicsController = new PhysicsController(MyGravity);
        inicialPos = this.gameObject.transform.position;
    }

    void Update()
    {
        if (resetPlayer)
        {
            ResetPlayerPosition();
        }
        if (active)
        {
            if (keyboard != null)
            {
                isGrounded = _raycastGround();

                // myPosition = gameObject.transform.position;
                
                if (isGrounded)
                {
                    canJump = true;
                }
                else
                {
                    canJump = false;
                    MyphysicsController.ApplyGravityToObject(movement, this.gameObject, isGrounded);
                }
                
                MovePlayer();

            }
        }
    }

    void ResetPlayerPosition()
    {
        gameObject.transform.position = inicialPos;
    }
    public bool _raycastGround()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(myGroundCheck.transform.position, Vector3.down, 0.1f))
        {
            // Debug.Log("Raycast is hiting");
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ReceiveInput(Vector2 _vector2)
    {
        movement = _vector2;
    }

    void MovePlayer()
    {
        float groundCheckY = myGroundCheck.transform.position.y;

        Transform myTransform = this.gameObject.transform;
        
        
        if (keyboard.anyKey.isPressed)
        {
            if (keyboard.sKey.isPressed)
            {
                // Debug.Log("MOVE DOWN");
                myTransform.Translate( -Vector3.forward.normalized * Time.deltaTime * velocityMovement);
            }

            if (keyboard.aKey.isPressed)
            {
                // Debug.Log("MOVE A");
                myTransform.Translate(  -Vector3.right.normalized * Time.deltaTime * velocityMovement);
            }

            if (keyboard.dKey.isPressed)
            {
                // Debug.Log("MOVE D");
                myTransform.Translate(  Vector3.right.normalized * Time.deltaTime * velocityMovement);
            }

            if (keyboard.wKey.isPressed)
            {
                // Debug.Log("MOVE W");

                myTransform.Translate(Vector3.forward.normalized * Time.deltaTime * velocityMovement);
            }

            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                // Debug.Log("Space key pressed");
                if (canJump)
                {
                   
                }
                
            }

        }
    }
    

}
    
    
    
    
    
    

