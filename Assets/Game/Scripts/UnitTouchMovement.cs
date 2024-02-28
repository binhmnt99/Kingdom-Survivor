using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace Kingdom
{
    public class UnitTouchMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 3.5f;
        [SerializeField] private Vector2 joystickSize = new Vector2(300, 300);
        [SerializeField] private FloatingJoystick joystick;
        [SerializeField] private NavMeshAgent navUnit;
        [SerializeField] private Animator unitAnimator;

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
            HandleFingerDown(finger);
        }

        private void Touch_onFingerUp(Finger finger)
        {
            HandleLoseFinger(finger);
        }

        private void Touch_onFingerMove(Finger finger)
        {
            HandleFingerMove(finger);
        }

        private void HandleFingerDown(Finger finger)
        {
            if (MovementFinger == null && finger.screenPosition.x <= Screen.width / 2f)
            {
                MovementFinger = finger;
                MovementAmount = Vector2.zero;
                joystick.gameObject.SetActive(true);
                joystick.RectTransform.sizeDelta = joystickSize;
                joystick.RectTransform.anchoredPosition = ClampStartPosition(finger.screenPosition);
            }
        }

        private void HandleFingerMove(Finger finger)
        {
            if (finger == MovementFinger)
            {
                unitAnimator.SetFloat("move",1f);
                navUnit.speed = movementSpeed;
                Vector2 knobPosition;
                float maxMovement = joystickSize.x / 2f;
                ETouch.Touch currentTouch = finger.currentTouch;

                if (Vector2.Distance(currentTouch.screenPosition, joystick.RectTransform.anchoredPosition) > maxMovement)
                {
                    knobPosition = (currentTouch.screenPosition - joystick.RectTransform.anchoredPosition).normalized * maxMovement;
                }
                else
                {
                    knobPosition = currentTouch.screenPosition - joystick.RectTransform.anchoredPosition;
                }

                joystick.Knob.anchoredPosition = knobPosition;
                MovementAmount = knobPosition / maxMovement;
            }
        }

        private void HandleLoseFinger(Finger finger)
        {
            if (finger == MovementFinger)
            {
                unitAnimator.SetFloat("move",0f);
                MovementFinger = null;
                joystick.Knob.anchoredPosition = Vector2.zero;
                joystick.gameObject.SetActive(false);
                MovementAmount = Vector2.zero;
            }
        }

        private Vector2 ClampStartPosition(Vector2 startPosition)
        {
            if (startPosition.x < joystickSize.x / 2)
            {
                startPosition.x = joystickSize.x / 2;
            }

            if (startPosition.y < joystickSize.y / 2)
            {
                startPosition.y = joystickSize.y / 2;
            }
            else if (startPosition.y > Screen.height - joystickSize.y / 2)
            {
                startPosition.y = Screen.height - joystickSize.y / 2;
            }

            return startPosition;
        }

        private void Update()
        {
            Vector3 scaledMovement = navUnit.speed * Time.deltaTime * new Vector3(MovementAmount.x, 0, MovementAmount.y);
            navUnit.transform.LookAt(navUnit.transform.position + scaledMovement, Vector3.up);
            navUnit.Move(scaledMovement);
        }
    }

}

