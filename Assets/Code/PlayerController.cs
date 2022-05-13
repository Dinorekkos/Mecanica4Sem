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

    [SerializeField] private float mass = 2;

    [SerializeField] public Vector3 speedVelocity;

    [SerializeField] private GameObject myGroundCheck;

    [SerializeField] private float jumpForce = 100f;


    private PhysicsController MyphysicsController;
    private Vector2 moveInput;
    private Keyboard keyboard;
    private float timeJumping = 0f;
    private float maxTimeJump = 0.05f;

    Canion canion;
    private bool active;
    public bool canJump;
    public bool isJumping;
    public bool isGrounded;

    public bool isFrictioning = false;
    public bool isDragging;
    
    bool canThrow = false;
    private bool isThrowing = false;

     PlanetData planetData;

     public Vector3 placeToMove;

    void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX || UNITY_EDITOR
        keyboard = Keyboard.current;
#endif
        active = true;
        MyphysicsController = new PhysicsController(MyGravity, speedVelocity, mass);
        currentPlanet = null;
    }

    void Update()
    {
        if (active)
        {
            MyphysicsController.GetGameObjectData(speedVelocity, MyGravity);
            
            //Receive gravity from the planet
            if (currentPlanet == null)
            {
                return;
            }
            else
            {
                if (!isGrounded)
                {
                    speedVelocity = MyphysicsController.SendGravityPlanetToObject(isGrounded, transform, currentPlanet, placeToMove);
                }
                
                isGrounded = _raycastGround();
                
                if (isGrounded)
                {
                    MyphysicsController.ApplyFrictionForce();
                    canJump = true;
                }
                else
                {
                    canJump = false;

                }
            }
            
            if(canion!=null)
            {
                canThrow = canion.CanThrow;
                isThrowing = canion.IsThrowing;
                if(isThrowing)
                {
                    speedVelocity = canion.ApplyCanionThrow();
                }
                
            }
           
           //Quitar is gropunded
            if(!canThrow)
            {
                MyphysicsController.ApplySpeedToObject(transform, speedVelocity); 
               //Stop gravity if object is in the canion
            }

            //Movement Player
            MovePlayer();
            
            
            //Align rotation player with the planet gravity
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, MyphysicsController.gravDirection) * transform.rotation;
            // transform.rotation = toRotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 01f);
        }
    }

    public bool _raycastGround()
    {
        
        if (planetData != null)
        {
            float offsetPlayer = 0.5f;
            float distanceToPlanetCenter = MyphysicsController.dirMagnitud.magnitude ;
            //if Player Is inside the planet ground move player to the top ground
            if (distanceToPlanetCenter <= planetData.PlanetRadius + offsetPlayer)
            {
                placeToMove = ((MyphysicsController.gravDirection * offsetPlayer) + MyphysicsController.gravDirection * planetData.PlanetRadius) + currentPlanet.transform.position ;
                transform.position = placeToMove;
                return true;
            }
            // if player is above planet ground, player is not grounded 
            if(distanceToPlanetCenter > planetData.PlanetRadius + offsetPlayer)
            {
                return false;
            }
        }
        
        
        return true;
    }


public void ReceiveInput(Vector2 myInput)
    {
        //Quitar speed velocity despues hahah
        moveInput = (myInput * speedVelocity) * Time.deltaTime * velocityMovement;
    }
    

    private void MovePlayer()
    {
        float x = moveInput.x;
        float z = moveInput.y;


        transform.Translate(x ,0 ,z );
        
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
            
            if (keyboard.spaceKey.wasPressedThisFrame && canJump && !isJumping)
            {

                isJumping = true;
            }
            
        }

        if (isJumping)
        {
            timeJumping += Time.deltaTime;

            if (timeJumping < maxTimeJump)
            {
                speedVelocity = MyphysicsController.ApplyAccelerationUpToObject() * jumpForce;
            }
            else
            {
                isJumping = false;
                timeJumping = 0;
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

            planetData = other.GetComponent<PlanetData>();

            MyGravity = planetData.PlanetGravity;
        }

        if (other.CompareTag("Canion"))
        {
            canion = other.GetComponent<Canion>();
            canThrow = true;
            canion.SetObjectToThrow(this.gameObject, speedVelocity, MyphysicsController, mass);
        }

        if(other.CompareTag("FrictionZone"))
        {
            isFrictioning = true;
            // Debug.Log("Se le aplica friction");
            // StartCoroutine("FrictionInPlayer");
        }
        if (other.CompareTag("DragZone"))
        {
            isDragging = true;
            StartCoroutine("DragInPlayer");
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Canion"))
        {
            if (canion != null)
            {
                canThrow = false;
                canion = null;
                
            }
        }
        if(other.CompareTag("FrictionZone"))
        {
             isFrictioning = false;
             // StopCoroutine("FrictionInPlayer");
        }

        if (other.CompareTag("DragZone"))
        {
            isDragging = false;
            StopCoroutine("DragInPlayer");
        }
    }

    IEnumerator FrictionInPlayer()
    {
        while (isFrictioning)
        {
            speedVelocity = MyphysicsController.ApplyFrictionForce();
            yield return null;

        }
    }

    IEnumerator DragInPlayer()
    {
        while (isDragging)
        {
            speedVelocity = MyphysicsController.ApplyDragginForce();
            yield return null;
        }

    }
    
    
    
}
    
    
    
    
    
    

