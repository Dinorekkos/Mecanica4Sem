using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    
    // gravity 9.81
    private float MyGravity = 1;
    private float acceleration;
    private float speedVelocity;

    void Start()
    {
        // ground = GameObject.FindGameObjectWithTag("Ground").transform;
        // Debug.Log(ground.name);
    }
    
    void Update()
    {
        
    }

    public PhysicsController(float _gravity, float _speedVelocity)
    {
        MyGravity = _gravity;
        speedVelocity = _speedVelocity;
    }
    
    public void GetGameObjectSpeed(float _speed)
    {
        speedVelocity = _speed;
    }

    public float ApplyGravityToObject (bool isGrounded)
    {
        
        if(!isGrounded)
        {
            speedVelocity += (MyGravity * Time.deltaTime);
        }
        else
        {
            speedVelocity = 0;
        }


        return speedVelocity;

        // Vector3 _gravityDirection = Vector3.zero;
        // _gravityDirection.y -= MyGravity * Time.deltaTime;
        // myVector = new Vector3 (0,_gravityDirection.y,0);

        // if(isGrounded)
        // { 
        // }
        // else
        // {
        //     gameObject.transform.position += myVector;
        // }


    }

    public float ApplyAccelerationToObject()
    {
        speedVelocity += acceleration;

        return speedVelocity;
    }

    
}
