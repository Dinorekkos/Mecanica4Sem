using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = System.Numerics.Quaternion;


public class Canion : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject selectedObject;
    [SerializeField] private GameObject placeToThrow;

    [SerializeField] private Vector3 canionDirection;
    private bool canThrowGO = false;
    private Keyboard _keyboard;
    

    private Vector3 canionPos;

    public bool CanThrow
    {
        get { return canThrowGO; }
        set { canThrowGO = value; }
    }

    public void SetObjectToThrow(GameObject _goToThrow, Vector3 _objectSpeed, bool Isgrounded)
    {
        // _goToThrow.transform.position = canionPos;
        selectedObject = _goToThrow;
        
            if (_goToThrow != null)
            {
                CanThrow = true;
            }

        Debug.Log(CanThrow);
    
    
    }
    void Start()
    {
        _keyboard = Keyboard.current;
        // placeToThrow.transform.position = canionPos;

    }
    
    public void ThrowObject()
    {
        if (CanThrow)
        {
            if (_keyboard.anyKey.isPressed)
            {
                if (_keyboard.enterKey.wasPressedThisFrame)
                {
                    Debug.Log("Throw Object to direction" + canionDirection);
                    
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        ThrowObject();
    }
}
