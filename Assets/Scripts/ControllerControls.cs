using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine;

public class ControllerControls : MonoBehaviour
{
    PlayerControls pc;
    public InputAction movement;
    public bool isAttackKeyPressed;
    public bool isJumpKeyPressed;
    public bool isJumpKeyHeld;
    public bool isDashingKeyPressed;
    public bool inventoryActive = false;
    public Vector2 leftJoystickMovement;
    
    private void Awake()
    {
        pc = new PlayerControls();
    }

    private void OnEnable()
    {
        pc.Gameplay.Enable();
    }

    private void Start()
    {
        movement = pc.Gameplay.Move;
        leftJoystickMovement.Set(movement.ReadValue<Vector2>().x, movement.ReadValue<Vector2>().y);
        pc.Gameplay.AttackPress.started += context => isAttackKeyPressed = true;
        pc.Gameplay.AttackPress.performed += context => isAttackKeyPressed = false;
        pc.Gameplay.AttackPress.canceled += context => isAttackKeyPressed = false;
        pc.Gameplay.JumpHold.started += context => { isJumpKeyPressed = true; isJumpKeyHeld = false; };
        pc.Gameplay.JumpHold.performed += context => { isJumpKeyPressed = false; isJumpKeyHeld = true; };
        pc.Gameplay.JumpHold.canceled += context => { isJumpKeyPressed = false; isJumpKeyHeld = false; };
        pc.Gameplay.Dash.started += context => isDashingKeyPressed = true;
        pc.Gameplay.Dash.performed += context => isDashingKeyPressed = false;
        pc.Gameplay.Dash.canceled += context => isDashingKeyPressed = false;
        pc.Gameplay.OpenInventory.started += Context => inventoryActive = !inventoryActive;
    }

    
    private void OnDisable()
    {
        pc.Gameplay.Disable();
    }

    private void FixedUpdate()
    {
        
    }
}
