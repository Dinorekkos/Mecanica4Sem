using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Canion : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject selectedObject;
    [SerializeField] private GameObject placeToThrow;

    [SerializeField] private Vector3 canionDirection;

    //[SerializeField] private PlayerController player;

    private float massObject;
    private bool canThrowGO = false;
    private bool isthrowing = false;
    private Keyboard _keyboard;
    
    private Quaternion canionRotation;
    private Vector3 canionPos;
    private Vector3 speed;

    public bool CanThrow
    
    {
        get { return canThrowGO; }
        set { canThrowGO = value; }
    }

    public void SetObjectToThrow(GameObject _goToThrow, Vector3 _objectSpeed, bool Isgrounded, float mass)
    {
        _goToThrow.transform.position = canionPos;
        selectedObject = _goToThrow;
        massObject = mass;
        speed = _objectSpeed;
        
            if (_goToThrow != null)
            {
                CanThrow = true;
               
            }

        Debug.Log(CanThrow);
    
    
    }
    void Start() {
        _keyboard = Keyboard.current;
       

        

    }
    
    public void ThrowObject()
    {
        Vector3 force = canionDirection  * 20;
        Vector3 acceleration = Vector3.zero; ;

        if (CanThrow)
        {

            speed = Vector3.zero;
            selectedObject.transform.position = canionPos;

            if (_keyboard.anyKey.isPressed)
            {
                if (_keyboard.enterKey.wasPressedThisFrame)
                {
                    isthrowing = true;
                    CanThrow = false;
                    acceleration = force / massObject;


                }
            }
        }

        if(isthrowing) 
        {



            speed += acceleration * Time.deltaTime;
            //selectedObject.transform.position += speed;

            Debug.Log("Throw Object to direction" + canionDirection);

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

        canionDirection = canionRotation.eulerAngles;

        //Debug.DrawRay(canionPos, canionRotation.eulerAngles);
        ThrowObject();
    }
}
