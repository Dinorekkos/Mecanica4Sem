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

    public void ApplySpeedToObject(Transform myTransform, Vector3 speedDir)
    {
        myTransform.position += -speedDir; 
    }
    public Vector3 SendGravityPlanetToObject(bool isGrounded, Transform myGameObject, Transform planetPos, Vector3 placeGravDir)
    {

        gravDirection = (myGameObject.transform.position - planetPos.transform.position).normalized;
        dirMagnitud = (myGameObject.transform.position - planetPos.transform.position);
        
        if(!isGrounded)
        {
            speedVelocity +=  gravDirection * (MyGravity * Time.deltaTime);
        }
        else
        {
            //Change para drag 
            // speedVelocity = Vector3.zero;
            // speedVelocity = placeGravDir.normalized * 0.1f;
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

        Vector3 friction = -speedVelocity * 0.5f;
        speedVelocity = friction ;
        return speedVelocity;
    }

    public Vector3 ApplyDragginForce()
    {
        float density = 10;
        float coeficentDrag = 1;
        float dragArea = 1;
        
        float dragNormal = Mathf.Sqrt((speedVelocity.x * speedVelocity.x) + (speedVelocity.y * speedVelocity.y) + (speedVelocity.z * speedVelocity.z));
        speedVelocity += -0.5f * density * dragNormal * coeficentDrag * dragArea * speedVelocity;
        
        return speedVelocity;
    }
    

}
