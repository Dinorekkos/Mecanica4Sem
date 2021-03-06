using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionObject : ColData
{
    private PhysicsController MyphysicsController;
    
    public PlayerController PlayerController;
    public Transform currentPlanet = null;
    public PlanetData planetData;

    public bool isPlayerController;
    
    private float MyGravity = 0;
    public float mass = 1;

    public Vector3 speedVelocity;
    private Vector3 placeToMove;



    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        if (!isPlayerController)
        {
            MyGravity = planetData.PlanetGravity;
            MyphysicsController = new PhysicsController(MyGravity, speedVelocity, mass);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlayerController)
        {
            MyphysicsController.GetGameObjectData(speedVelocity, MyGravity);

            speedVelocity = MyphysicsController.SendGravityPlanetToObjectCol(isGrounded, transform, currentPlanet);

            isGrounded = _raycastGround();
            if(isGrounded)
            {
                MyphysicsController.ApplyFrictionForce();
            }
            MyphysicsController.ApplySpeedToObject(transform, speedVelocity);

            //Align rotation player with the planet gravity
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, MyphysicsController.gravDirection) * transform.rotation;
            // transform.rotation = toRotation;
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 01f);
        }
        else
        {
            speedVelocity = PlayerController.speedVelocity;
            mass = PlayerController.mass;
        }
        

    }

     public bool _raycastGround()
    {
        
        if (planetData != null)
        {
            float offset = 0.5f;
            float distanceToPlanetCenter = MyphysicsController.dirMagnitud.magnitude;
            //if Player Is inside the planet ground move player to the top ground
            if (distanceToPlanetCenter <= planetData.PlanetRadius + offset)
            {
                placeToMove = ((MyphysicsController.gravDirection * offset) + MyphysicsController.gravDirection * planetData.PlanetRadius) + currentPlanet.transform.position ;
                transform.position = placeToMove;
                return true;
            }
            // if player is above planet ground, player is not grounded 
            if(distanceToPlanetCenter > planetData.PlanetRadius + offset)
            {
                return false;
            }
        }
        
        
        return true;
    }
}
