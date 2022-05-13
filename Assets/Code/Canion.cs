using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Canion : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject selectedObject;
    [SerializeField] private GameObject place1;
    [SerializeField] private GameObject place2;


    [SerializeField] private Vector3 canionDirection;

    //[SerializeField] private PlayerController player;

    private float massObject;
    private float timeThrowing;
    private float maxTimeThrowing = 0.05f;
    private bool canThrowGO = false;
    private bool isthrowing = false;
    private Keyboard _keyboard;
    
    private Quaternion canionRotation;
    private Vector3 canionPos;
    private Vector3 speed;

    private PhysicsController physics;
    public bool CanThrow
    
    {
        get { return canThrowGO; }
        set { canThrowGO = value; }
    }

    public bool IsThrowing
    {
        get
        {
            return isthrowing;
        }
    }

    public void SetObjectToThrow(GameObject _goToThrow, Vector3 _objectSpeed, PhysicsController _physicsController, float _mass)
    {
        _goToThrow.transform.position = canionPos;
        selectedObject = _goToThrow;
        massObject = _mass;
        speed = _objectSpeed;
        physics = _physicsController;
        
            if (_goToThrow != null)
            {
                CanThrow = true;
               
            }

        // Debug.Log(CanThrow);
    
    
    }
    void Start() {
        _keyboard = Keyboard.current;
        
    }
    
    public void ThrowObject()
    {
        Vector3 force = canionDirection  * 100f;
        Vector3 acceleration = Vector3.zero; ;

        if (CanThrow)
        {

            speed = Vector3.zero;
            selectedObject.transform.position = canionPos;
            

            if (_keyboard.anyKey.isPressed)
            {
                if (_keyboard.enterKey.wasPressedThisFrame && CanThrow && !isthrowing)
                {
                    isthrowing = true;
                    CanThrow = false;
                    acceleration = force / massObject;


                }
            }
        }

        if(isthrowing)
        {
            timeThrowing += Time.deltaTime;
            if (timeThrowing < maxTimeThrowing)
            {
                speed += acceleration * Time.deltaTime;
            }
            else
            {
                isthrowing = false;
                timeThrowing = 0;
                
            }

            // Debug.Log("Throw Object to direction" + canionDirection);

        }
        else
        {
            // Debug.Log("Finish Throwing object");

            // selectedObject = null;
        }


    }

    public Vector3 ApplyCanionThrow() {

        return speed;
    }

    // Update is called once per frame
    void Update()
    {
        canionPos = this.gameObject.transform.position;
        canionRotation = this.gameObject.transform.rotation;

        //canionDirection = canionRotation.eulerAngles;

        canionDirection = (place1.transform.position - place2.transform.position).normalized;

        // Debug.DrawRay(canionPos, canionDirection);

        ThrowObject();
    }
}
