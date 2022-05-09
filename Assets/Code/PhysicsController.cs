using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    
    // gravity 9.81
    private float MyGravity = 1;
    private float myMass;
    public Vector3 gravDirection;
    public Vector3 dirMagnitud;
    private Vector3 acceleration;
    private Vector3 speedVelocity;

   
    public PhysicsController(float _gravity, Vector3 _speedVelocity, float _mass)
    {
        MyGravity = _gravity;
        speedVelocity = _speedVelocity;
        myMass = _mass;
    }
    
    public void GetGameObjectData(Vector3 _speed , float _gravity)
    {
        speedVelocity = _speed;
        MyGravity = _gravity;

    }

    public void ApplyGravityToObject(Transform myTransform, Vector3 speedDir)
    {
        myTransform.position += -speedDir; 
    }
    public Vector3 SendGravityPlanetToObject(bool isGrounded, Transform myGameObject, Transform planetPos)
    {

        gravDirection = (myGameObject.transform.position - planetPos.transform.position).normalized;
        dirMagnitud = (myGameObject.transform.position - planetPos.transform.position);
        
        if(!isGrounded)
        {
            speedVelocity +=  gravDirection * (MyGravity * Time.deltaTime);
        }
        else
        {
            speedVelocity = Vector3.zero;
    
        }
        
        return speedVelocity;
        
    }

    public Vector3 ApplyAccelerationUpToObject()
    {
        acceleration = -0.5f * (gravDirection);
        speedVelocity += acceleration;

        return speedVelocity;
    }
    
    public Vector3 ApplyDragForce(){


        return speedVelocity;
    }

}
