using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{

    Transform ground;
    private float MyAcceleration;
    // gravity 9.81
    private float MyGravity = 9.81f;
    Vector3 groundPos;

    public Vector3 GroundPosition
    {
        get {return groundPos;}
    }

    void Start()
    {
        ground = GameObject.FindGameObjectWithTag("Ground").transform;
        Debug.Log(ground.name);
    }
    
    void Update()
    {
        
    }

    public PhysicsController(float _gravity)
    {
        MyGravity = _gravity;
    }

    public void ApplyGravityToObject(Vector3 vector, GameObject gameObject, GameObject groundCheck)
    {
        Vector3 _gravityDirection = Vector3.zero;
        _gravityDirection.y = -MyGravity * Time.deltaTime;
        vector = new Vector3 (0,_gravityDirection.y,0);
        
        if(groundCheck.transform.position.y <= groundPos.y)
        {
            groundPos.y = groundPos.y + 1;
            groundCheck.transform.position = groundPos;
        }
        else
        {
            gameObject.transform.position += vector;
        }
        
        
    }

    public void ApplyAcceleration()
    {
        
    }
}
