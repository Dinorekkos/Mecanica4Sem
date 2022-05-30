using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetData : MonoBehaviour
{

    [SerializeField] private float planetGravity;
    [SerializeField] private float planetRadius = 5f;

    public float PlanetGravity
    {
        get { return planetGravity;}
        set { planetGravity = value; }
    }

    public float PlanetRadius{
        get {return planetRadius;}
        
    
    }
    
    

  
}
