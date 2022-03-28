using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    Transform ground;

    private Vector3 MyAcceleration;
    // gravity 9.81
    private float MyGravity = 9.81f;
    Vector3 groundPos;
    
    float speedVelocity;

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

    public float ApplyGravityToObject (Vector3 myVector, GameObject gameObject, bool isGrounded)
    {


        if(isGrounded)
        {
            speedVelocity += (MyGravity * Time.deltaTime);
        }
        
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
        
        return MyGravity;
        
    }

    // public Vector3 ApplyAccelerationToObject(Vector3 myVector3, float velocity, float maxHeigh)
    // {
        
    // }
    
}
