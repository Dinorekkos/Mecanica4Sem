using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public GameObject[] collisionObjects;

    private bool isApplyingCol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

                    if (distance <= 1)
                    {
                        CollisionObject col1 = otherTransform.gameObject.GetComponent<CollisionObject>();
                        CollisionObject col2 = otherTransform.gameObject.GetComponent<CollisionObject>();
                        
                        ApplyCollisionForces(col1.speedVelocity, col2.speedVelocity, col1.mass, col2.mass,
                            col1.transform, col2.transform);
                        
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


    void ApplyCollisionForces(Vector3 speedVelocity1, Vector3 speed2, float mass1, float mass2, Transform object1, Transform object2)
    {
        Debug.Log("<color=#E87FFF>APPLY COLLISION </color>" );

        
    }


}
