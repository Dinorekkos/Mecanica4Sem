using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    [Header("Physics")] [SerializeField] private float MyGravity = 9.81f;
    [SerializeField] 
    private Transform currentPlanet = null;

    [Header("Player")] [SerializeField] private float velocityMovement = 1;

    [SerializeField] public Vector3 speedVelocity;

    [SerializeField] private GameObject myGroundCheck;

    private PhysicsController MyphysicsController;

    private Vector2 moveInput;
    private float maxHeightJump = 1.2f;

    private Keyboard keyboard;


    private bool active;
    private bool canJump;

    public bool isGrounded;


    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        keyboard = Keyboard.current;
#endif
        active = true;
        MyphysicsController = new PhysicsController(MyGravity, speedVelocity);
        currentPlanet = null;
    }

    void Update()
    {
        if (active)
        {
            isGrounded = _raycastGround();

            //Physics
            MyphysicsController.GetGameObjectSpeed(speedVelocity);
            //Receive gravity from the planet
            if (currentPlanet == null)
            {
                return;
            }
            else
            {
                speedVelocity = MyphysicsController.SendGravityPlanetToObject(isGrounded, transform, currentPlanet);
                MyphysicsController.ApplyGravityToObject(transform, speedVelocity);
            }
          

            //Movement Player
            if (keyboard != null)
            {
                MovePlayer();
            }

            if (isGrounded)
            {
                canJump = true;
            }
            else
            {
                canJump = false;

            }


            //Align rotation player with the planet gravity
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, MyphysicsController.gravDirection) * transform.rotation;
            // transform.rotation = toRotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 01f);
        }
    }

    public bool _raycastGround()
    {
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(myGroundCheck.transform.position, -transform.up, out hit, 0.1f))
        {
            if (hit.collider.isTrigger)
            {
                return false;
            }
            if (!hit.collider.isTrigger)
            {
                return true;
            }
        }
        
        return false;
    }


public void ReceiveInput(Vector2 myInput)
    {
        moveInput = myInput * Time.deltaTime * velocityMovement;
    }
    

    private void MovePlayer()
    {
        float x = moveInput.x;
        float z = moveInput.y;
        
        transform.Translate(x,0,z);

        if (keyboard.anyKey.isPressed)
        {
            //Rotate Player 
            if (keyboard.eKey.isPressed)
            {
                transform.Rotate(0,150 * Time.deltaTime , 0);
            }
            if (keyboard.qKey.isPressed)
            {
                transform.Rotate(0,-150 * Time.deltaTime , 0);
            }
            
            if (keyboard.spaceKey.isPressed && canJump)
            {
                speedVelocity = MyphysicsController.ApplyAccelerationToObject(transform);
                transform.position += speedVelocity * maxHeightJump * Time.deltaTime * 200f; 
               
               Debug.Log(speedVelocity);
            }
            
            
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Planet"))
        {
            if (currentPlanet != null)
            {
                currentPlanet = null;
            }
            currentPlanet = other.gameObject.transform;
        }

        if (other.CompareTag("Canion"))
        {
            Canion canion = other.GetComponent<Canion>();
            canion.SetObjectToThrow(this.gameObject, speedVelocity);

            // Debug.Log("touch canion");
        }
    }
    
    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Planet"))
    //     {
    //         if (currentPlanet != null)
    //         {
    //             currentPlanet = null;
    //         }
    //         // currentPlanet = other.gameObject.transform;
    //     }
    // }
}
    
    
    
    
    
    

