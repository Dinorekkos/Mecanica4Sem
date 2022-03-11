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
    
    // public Vector3 GroundPosition
    // {
    //     get {return groundPos;}
    // }

    void Start()
    {
        // ground = GameObject.FindGameObjectWithTag("Ground").transform;
        // Debug.Log(ground.name);
    }
    
    void Update()
    {
        
    }

    public PhysicsController(float _gravity)
    {
        MyGravity = _gravity;
    }

    public void ApplyGravityToObject(Vector3 vector, GameObject gameObject, bool isGrounded)
    {
        
        Vector3 _gravityDirection = Vector3.zero;
        _gravityDirection.y -= MyGravity * Time.deltaTime;
        vector = new Vector3 (0,_gravityDirection.y,0);
        
        if(isGrounded)
        { 
        }
        else
        {
            gameObject.transform.position += vector;
        }
        
        
    }

    public float ApplyAccelerationToObject(Vector3 myVector3, float velocity, float maxHeigh)
    {
        Vector3 _acelerationDir = Vector3.zero;

        _acelerationDir.y = velocity * Time.deltaTime;

        myVector3 = new Vector3(0, _acelerationDir.y, 0);

        if (_acelerationDir.y >= maxHeigh)
        {
            _acelerationDir.y = 0;
        }
        
        
        return myVector3.y;


        // Vector3 velocityDir = Vector3.zero;
        // Vector3 acceleration = Vector3.zero;
        //
        // acceleration.y = 500;
        // velocityDir.y += acceleration.y;
        //
        //
        // if (velocityDir.y >= 5)
        // {
        //     velocityDir.y = 0;
        // }
        //
        // myVector3.y = velocityDir.y * Time.deltaTime; 
        //
        // // Debug.Log(offsetY);
        //
        // return myVector3;

    }
}
