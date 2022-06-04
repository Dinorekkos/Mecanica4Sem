using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public GameObject[] collisionObjects;
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
            float distance = 0;

            foreach (GameObject otherTransform in collisionObjects)
            {
                if (otherTransform.name != objectTransform.name)
                {
                    distance = Mathf.Sqrt( Mathf.Pow((objectTransform.transform.position.x - otherTransform.transform.position.x),2) +
                                            Mathf.Pow((objectTransform.transform.position.y - otherTransform.transform.position.y),2) + 
                                            Mathf.Pow((objectTransform.transform.position.z - otherTransform.transform.position.z),2));

                    if (distance <= 1)
                    {
                        // if (objectTransform.GetComponent<PlayerController>())
                        // {
                        //     PlayerController playerController = objectTransform.GetComponent<PlayerController>();
                        //     Vector3 speedVelocity = playerController.speedVelocity;
                        //     float mass = playerController.mass;
                        // }
                        // else if(objectTransform.GetComponent<>())
                        Debug.Log("<color=#E87FFF>Collison between =  </color>" + otherTransform.name+ " " + objectTransform.name +" " + distance);
                    }
                    else
                    {
                        // otherTransform.GetComponent<ColData>().isColliding = false;
                        // objectTransform.GetComponent<ColData>().isColliding = false;
                        Debug.Log("<color=#FF5751>NOOO COLLISION =  </color>");
                    }
                    
                }
            }
            
        }
    }


    void ApplyCollisionForces(Vector3 speedVelocity, float mass, Transform objectToApply)
    {
        
    }


}
