using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    
    public void MovePoint(Vector3 placeToMove)
    {
        transform.position = placeToMove;
    }
    
}
