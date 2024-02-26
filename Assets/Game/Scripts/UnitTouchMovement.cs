using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class UnitTouchMovement : MonoBehaviour
{
    [SerializeField] private Vector2 joystickSize;
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private NavMeshAgent Unit;

    private Finger MovementFinger;
    private Vector2 MovementAmount;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += Touch_onFingerDown;
        ETouch.Touch.onFingerUp += Touch_onFingerUp;
        ETouch.Touch.onFingerMove += Touch_onFingerMove;
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
        ETouch.Touch.onFingerDown -= Touch_onFingerDown;
        ETouch.Touch.onFingerUp -= Touch_onFingerUp;
        ETouch.Touch.onFingerMove -= Touch_onFingerMove;
    }

    private void Touch_onFingerDown(Finger finger)
    {
        throw new NotImplementedException();
    }

    private void Touch_onFingerUp(Finger finger)
    {
        throw new NotImplementedException();
    }

    private void Touch_onFingerMove(Finger finger)
    {
        throw new NotImplementedException();
    }

    private void HandleFingerDown(Finger finger)
    {
        if (MovementFinger == null && finger.screenPosition.x <= Screen.width / 2f)
        {
            MovementFinger = finger;
            MovementAmount = Vector2.zero;
            joystick.gameObject.SetActive(false);
            //joystick.Rec = joystickSize;
        }
    }
}
