using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 rawMovementInput { get; private set; }
    public int NormalizedInputX { get; private set; }
    public int NormalizedInputY { get; private set; }
    public bool jumpInput { get; private set;  }
    public bool dashInput { get; private set; }

    public AttackInputs attackInputs;

    [SerializeField] private float inputHoldTime = 0.1f;

    private float jumpInputStartTime;
    private float dashInputStartTime;
    private float primaryAttackStartTime;

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        rawMovementInput = context.ReadValue<Vector2>();
        NormalizedInputX = Mathf.RoundToInt(rawMovementInput.x);
        NormalizedInputY = Mathf.RoundToInt(rawMovementInput.y);
    }

    private void Update()
    {
        CheckInputHoldTime();
    }

    public void OnPrimaryAttackInput(InputAction.CallbackContext context)
    {
        if (!PauseMenu.isPaused)
        {
            if (context.started)
            {
                //Debug.Log("attacking");
                attackInputs.primaryAttack = true;
                primaryAttackStartTime = Time.time;
            }

            if (context.canceled)
            {
                attackInputs.primaryAttack = false;
            }
        }
    }

    public void OnSecondaryAttackInput(InputAction.CallbackContext context)
    {
        if (!PauseMenu.isPaused)
        {
            if (context.started)
            {
                attackInputs.secondaryAttack = true;
            }
            if (context.canceled)
            {
                attackInputs.secondaryAttack = false;
            }
        }
    }

    public void OnPauseInput(InputAction.CallbackContext context)
    {
        if (context.started)
            GameObject.Find("GameManager").GetComponent<PauseMenu>().PauseResumeGame();
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (!PauseMenu.isPaused)
        {
            if (context.started)
            {
                jumpInput = true;
                jumpInputStartTime = Time.time;
            }

            if (context.performed)
            {

            }

            if (context.canceled)
            {
                jumpInput = false;
            }
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (!PauseMenu.isPaused)
        {
            if (context.started)
            {
                dashInput = true;
                dashInputStartTime = Time.time;
            }

            if (context.canceled)
            {
                dashInput = false;
            }
        }
    }

    private void CheckInputHoldTime()
    {
        if (!PauseMenu.isPaused)
        {
            if (Time.time > dashInputStartTime + inputHoldTime)
            {
                dashInput = false;
            }
            if (Time.time > primaryAttackStartTime + inputHoldTime)
            {
                attackInputs.primaryAttack = false;
            }
        }
    }
    public void UseJumpInput() => jumpInput = false;
    public void UseDashInput() => dashInput = false;

    public void UsePrimaryAttackInput() => attackInputs.primaryAttack = false;
    public void UseSecondaryAttackInput() => attackInputs.secondaryAttack = false;

}

