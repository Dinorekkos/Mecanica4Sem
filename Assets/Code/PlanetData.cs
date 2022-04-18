using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetData : MonoBehaviour
{

    [SerializeField] private float planetGravity;

    public float PlanetGravity
    {
        get { return planetGravity;}
        set { planetGravity = value; }
    }



    public void CheckPlanetGround()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
