using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    
    // gravity 9.81
    private float MyGravity = 1;
    private float myMass;
    public Vector3 gravDirection;
    private Vector3 acceleration;
    private Vector3 speedVelocity;

    void Start()
    {
        // ground = GameObject.FindGameObjectWithTag("Ground").transform;
        // Debug.Log(ground.name);
    }
    
    void Update()
    {
        
    }

    public PhysicsController(float _gravity, Vector3 _speedVelocity, float _mass)
    {
        MyGravity = _gravity;
        speedVelocity = _speedVelocity;
        myMass = _mass;
    }
    
    public void GetGameObjectSpeed(Vector3 _speed)
    {
        speedVelocity = _speed;
    }

    public void ApplyGravityToObject(Transform myTransform, Vector3 speedDir)
    {
        myTransform.position += -speedDir; //* Time.deltaTime;
    }
    public Vector3 SendGravityPlanetToObject(bool isGrounded, Transform myGameObject, Transform planetPos)
    {

        gravDirection = (myGameObject.transform.position - planetPos.transform.position).normalized;
        
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

    public Vector3 ApplyAccelerationUpToObject( Transform _transform)
    {
        acceleration = -0.5f * (gravDirection);
        speedVelocity += acceleration;
        //Debug.Log(speedVelocity);

        return speedVelocity;
    }

}
