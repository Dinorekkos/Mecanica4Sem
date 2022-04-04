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

    [SerializeField] private Quaternion canionDirection;
    private bool canThrowGO = false;
    private Keyboard _keyboard;
    

    private Vector3 canionPos;

    public bool CanThrow
    {
        get { return canThrowGO; }
        set { canThrowGO = value; }
    }

    public void SetObjectToThrow(GameObject _goToThrow, Vector3 _objectSpeed)
    {
        _goToThrow.transform.position = canionPos;
        selectedObject = _goToThrow;
        
        if (_goToThrow != null)
        {
            CanThrow = true;
        }
    
        if (CanThrow)
        {
            _objectSpeed = new Vector3();
        }
    
    
    }
    void Start()
    {
        _keyboard = Keyboard.current;
        placeToThrow.transform.position = canionPos;

    }

    public void ThrowObject()
    {
        if (CanThrow)
        {
            if (_keyboard.anyKey.isPressed)
            {
                if (_keyboard.spaceKey.wasPressedThisFrame)
                {
                    Debug.Log("Throw Object");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
