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
    [SerializeField] private float timeJump = 0;

    [SerializeField] private bool resetPlayer;

    [SerializeField] private GameObject myGroundCheck;

    private PhysicsController MyphysicsController;
    
    private Vector3 inicialPos;
    private Vector3 myPosition;

    private float maxTimeJump;
    
    
    private Keyboard keyboard;
    
    
    private bool active;
    private bool canJump;
    private bool isJumping;
    public bool isGrounded;

    
    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        keyboard = Keyboard.current;
#endif
        active = true;
        MyphysicsController = new PhysicsController(MyGravity, speedVelocity);
        inicialPos = gameObject.transform.position;
        maxTimeJump = 0.5f;
        timeJump = 0;
    }

    void Update()
    {
        MyphysicsController.GetGameObjectSpeed(speedVelocity);
        
        if (resetPlayer)
        {
            ResetPlayerPosition();
        }
        if (active)
        {
            if (keyboard != null)
            {
                isGrounded = _raycastGround();
                speedVelocity = MyphysicsController.ApplyGravityToObject(isGrounded);
                
                if (isGrounded)
                {
                    canJump = true;
                }
                else
                {
                    transform.position += new Vector3(0, -speedVelocity * Time.deltaTime);
                    canJump = false;
                    timeJump = 0;
                }
                
                if (!isGrounded && !(timeJump >= maxTimeJump))
                {
                    speedVelocity = MyphysicsController.ApplyAccelerationToObject();
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

    void MovePlayer()
    {
        
        Transform myTransform = this.gameObject.transform;
        
        if (keyboard.anyKey.isPressed)
        {
            if (keyboard.sKey.isPressed)
            {
                myTransform.Translate( -Vector3.forward.normalized * Time.deltaTime * velocityMovement);
            }

            if (keyboard.aKey.isPressed)
            {
                myTransform.Translate(  -Vector3.right.normalized * Time.deltaTime * velocityMovement);
            }

            if (keyboard.dKey.isPressed)
            {
                myTransform.Translate(  Vector3.right.normalized * Time.deltaTime * velocityMovement);
            }

            if (keyboard.wKey.isPressed)
            {
                myTransform.Translate(Vector3.forward.normalized * Time.deltaTime * velocityMovement);
            }

            if (keyboard.spaceKey.isPressed && canJump)
            {
                Debug.Log("<color=#FFAE4D> SPACE PRESSED </color>");
                isJumping = true;
                timeJump += Time.deltaTime;
                
            }

            if (keyboard.spaceKey.wasReleasedThisFrame)
            {
                Debug.Log("<color=#E18FFF> SPACE IS RELEASED </color>");
                isJumping = false;
                timeJump = 0;
                canJump = false;
            }
            
            

        }
    }
    

}
    
    
    
    
    
    

