using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    
    // gravity 9.81
    private float MyGravity = 1;
    private float myMass;
    public bool isColliding;
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

    public void ApplySpeedToObject(Transform myTransform, Vector3 speedDir)
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
            // Debug.Log("Is grounded");
            //Change para drag 
            speedVelocity = Vector3.zero;
            // speedVelocity = placeGravDir.normalized * 0.1f;
        }
        
        return speedVelocity;
        
    }
    public Vector3 SendGravityPlanetToObjectCol(bool isGrounded, Transform myGameObject, Transform planetPos)
    {

        gravDirection = (myGameObject.transform.position - planetPos.transform.position).normalized;
        dirMagnitud = (myGameObject.transform.position - planetPos.transform.position);
        
        if(!isGrounded)
        {
            speedVelocity +=  gravDirection * (MyGravity * Time.deltaTime);
        }
        
        return speedVelocity;
        
    }

    public Vector3 ApplyAccelerationUpToObject()
    {
        acceleration = gravDirection * -1f;
        speedVelocity += acceleration;

        return speedVelocity;
    }
    
    public Vector3 ApplyFrictionForce(){
       
        float mu = 1;
        // Vector3 friction = -speedVelocity * 0.5f;
        
        Vector3 normalized = new Vector3(speedVelocity.x,speedVelocity.y,speedVelocity.z).normalized;
        
        Vector3 friction = -1 * mu * (myMass * MyGravity) * normalized;
        
        if (friction.magnitude < speedVelocity.magnitude)
        {
            speedVelocity = Vector3.zero;
        }
        else
        {
            speedVelocity += friction;
        }
        // Debug.Log("Speed magnitude " + speedVelocity.magnitude);
        
        return speedVelocity;
    }

    public Vector3 ApplyDragginForce()
    {
        float density = 10;
        float coeficentDrag = 1;
        float dragArea = 1;
        
        float dragNormal = Mathf.Sqrt((speedVelocity.x * speedVelocity.x) + (speedVelocity.y * speedVelocity.y) + (speedVelocity.z * speedVelocity.z));
        // speedVelocity += -0.5f * density * dragNormal * coeficentDrag * dragArea * speedVelocity;
        speedVelocity += -0.1f * density * dragNormal * coeficentDrag * dragArea * speedVelocity;
        
        return speedVelocity;
    }
    
    
    
    
    
}
