using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    
    // gravity 9.81
    public Vector3 gravDirection;
    private float MyGravity = 1;
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

    public PhysicsController(float _gravity, Vector3 _speedVelocity)
    {
        MyGravity = _gravity;
        speedVelocity = _speedVelocity;
    }
    
    public void GetGameObjectSpeed(Vector3 _speed)
    {
        speedVelocity = _speed;
    }

    public void ApplyGravityToObject(Transform myTransform, Vector3 gravityDir)
    {
        myTransform.position += -gravityDir * Time.deltaTime;
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

    public Vector3 ApplyAccelerationToObject( Transform _transform)
    {
        acceleration = _transform.localEulerAngles;
        // acceleration = Vector3.up;
        speedVelocity += acceleration;

        return speedVelocity;
    }

}
