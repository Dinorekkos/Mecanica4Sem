using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;

public class PointsController : MonoBehaviour
{
    public static PointsController Instance;
    private PlanetData _planetData;
    public Transform[] _places;
    public Point[] _points;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        MyTimer.Instance.OnTimerFinished += MovePoints;
    }

    // private void Update()
    // {
    //     // if (keyboard.mKey.wasPressedThisFrame)
    //     // {
    //     //     MovePoints();
    //     // }
    // }

    void MovePoints()
    {
        Debug.Log("<color=#7FF5FF>Se llama MovePoints onTimerFinished</color>");
        for (int x = 0; x < _points.Length; x++)
        {
            Point point = _points[x].gameObject.GetComponent<Point>();
            point.HandleState(true);
            point.MovePoint(GetRandomPos());
        }

    }

    private Vector3 GetRandomPos()
    {
        
        int random = Random.Range(0, _places.Length);
        // int previewRandom = 0;
        //
        // if (random == previewRandom)
        // {
        //     random++;
        //     if (random >= _places.Length)
        //     {
        //         random = 0;
        //     }
        //     
        //     
        // }
        //
        // previewRandom = random;
        Vector3 position = new Vector3(_places[random].transform.position.x,_places[random].transform.position.y, _places[random].transform.position.z );
        
        
        return position;
    }
}
