using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    private float MyAcceleration;
    // gravity 9.81
    private float MyGravity = 9.81f;
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public PhysicsController(float _gravity)
    {
        MyGravity = _gravity;
    }

    public void ApplyGravityToObject(GameObject myGameObject)
    {
        Vector3 direction = Vector3.zero;
        direction.y = -MyGravity * Time.deltaTime;
        myGameObject.transform.position = new Vector3(0, direction.y, 0);
    }

    public void ApplyAcceleration()
    {
        
    }
}
