using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public GameObject[] collisionObjects;

    private bool isApplyingCol;

    private Vector3 distanceVector;
    public float e = 1;

    void Update()
    {
        MeasureDistance();
        
    }

    void MeasureDistance()
    {
        foreach (GameObject objectTransform in collisionObjects)
        {
            foreach (GameObject otherTransform in collisionObjects)
            {
                if (otherTransform.name != objectTransform.name)
                {
                    float distance = 0;
                    distance = Mathf.Sqrt( Mathf.Pow((objectTransform.transform.position.x - otherTransform.transform.position.x),2) +
                                            Mathf.Pow((objectTransform.transform.position.y - otherTransform.transform.position.y),2) + 
                                            Mathf.Pow((objectTransform.transform.position.z - otherTransform.transform.position.z),2));

                    distanceVector = (objectTransform.transform.position - otherTransform.transform.position);

                    if (distance <= 1)//(distance <= (r1+r2))
                    {
                        CollisionObject col1 = otherTransform.gameObject.GetComponent<CollisionObject>();
                        CollisionObject col2 = otherTransform.gameObject.GetComponent<CollisionObject>();
                        
                      Vector3 appliedSpeed1 = ApplyCollisionForces1(col1.speedVelocity, col2.speedVelocity, col1.mass, col2.mass,
                             distanceVector);
                        
                     Vector3 appliedSpeed2 =  ApplyCollisionForces2(col1.speedVelocity, col2.speedVelocity, col1.mass, col2.mass,
                             distanceVector);

                        col1.speedVelocity = appliedSpeed1;
                        col2.speedVelocity = appliedSpeed2;


                        // Debug.Log("<color=#E87FFF>Collison between =  </color>" + otherTransform.name+ " " + objectTransform.name +" " + distance);
                    }
                    else if(distance > 1)
                    {
                        // Debug.Log("<color=#FF5751>NOOO COLLISION =  </color>");
                    }
                    
                }
            }
            
        }
    }

   

    Vector3 ApplyCollisionForces1(Vector3 speed1, Vector3 speed2, float mass1, float mass2,
        Vector3 distance)
    {
        Debug.Log("<color=#E87FFF>APPLY COLLISION </color>");

        Vector3 distanceVN = distance.normalized; 

        float productOne = (speed1.x * distanceVN.x) + (speed1.y * distanceVN.y) + (speed1.z * distanceVN.z);
        float productTwo = (speed2.x * distanceVN.x) + (speed2.y * distanceVN.y) + (speed2.z * distanceVN.z);

        float prime = (((mass1 * productOne) + (mass2 * productTwo)) - ((mass2 * e) * (productOne - productTwo))) /
                         (mass1 + mass2);

        float acceleration1 = prime - productOne;
        float acceleration2 = (mass1 / mass2) * acceleration1;
        
        Vector3 vPrime1 = productOne * distanceVector.normalized;
        Vector3 vPrime2 = productTwo * distanceVector.normalized;

        Vector3 accelerationDir1 = acceleration1 * distanceVector.normalized;
        Vector3 accelerationDir2 = acceleration2 * distanceVector.normalized;



        Vector3 collisionSpeed1 = vPrime1 + accelerationDir1;
        Vector3 collisionSpeed2 = vPrime2 + accelerationDir2;


        speed1 = collisionSpeed1;
        speed2 = -collisionSpeed2;

        return speed1;
    }

    Vector3 ApplyCollisionForces2(Vector3 speed1, Vector3 speed2, float mass1, float mass2,
         Vector3 distance)
    {
        Debug.Log("<color=#E87FFF>APPLY COLLISION </color>");

        Vector3 distanceVN = distance.normalized;

        float productOne = (speed1.x * distanceVN.x) + (speed1.y * distanceVN.y) + (speed1.z * distanceVN.z);
        float productTwo = (speed2.x * distanceVN.x) + (speed2.y * distanceVN.y) + (speed2.z * distanceVN.z);

        float prime = (((mass1 * productOne) + (mass2 * productTwo)) - ((mass2 * e) * (productOne - productTwo))) /
                         (mass1 + mass2);

        float acceleration1 = prime - productOne;
        float acceleration2 = (mass1 / mass2) * acceleration1;

        Vector3 vPrime1 = productOne * distanceVector.normalized;
        Vector3 vPrime2 = productTwo * distanceVector.normalized;

        Vector3 accelerationDir1 = acceleration1 * distanceVector.normalized;
        Vector3 accelerationDir2 = acceleration2 * distanceVector.normalized;



        Vector3 collisionSpeed1 = vPrime1 + accelerationDir1;
        Vector3 collisionSpeed2 = vPrime2 + accelerationDir2;


        speed1 = collisionSpeed1;
        speed2 = -collisionSpeed2;

        return speed2;
    }


}
