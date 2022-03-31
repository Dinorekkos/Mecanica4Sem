using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private PlayerActions _playerActions;
    private PlayerActions.MovementActions playerMovementActions;


    private Vector2 _vector2MovInput;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerActions = new PlayerActions();
        playerMovementActions = _playerActions.Movement;

        playerMovementActions.Walk.performed += ctx => _vector2MovInput = ctx.ReadValue<Vector2>();
    }

    private void Update()
    {
        // _playerController.ReceiveInput(_vector2MovInput);
    }

    private void OnEnable()
    {
        _playerActions.Enable();
    }

    private void OnDestroy()
    {
        _playerActions.Disable();
    }
}
