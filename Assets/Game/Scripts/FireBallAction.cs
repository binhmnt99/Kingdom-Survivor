using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public class FireBallAction : BaseAction
    {
        public override string GetActionName() => "MagicShot";
        public override void TakeAction()
        {
            FloatingJoystick joystick = GetComponent<UnitTouchMovement>().GetJoystick();
            Debug.Log(joystick.gameObject.activeSelf);
            if (joystick.gameObject.activeSelf == false)
            {
                unitAnimator.SetTrigger("isAttacking");
            }
            else
            {
                unitAnimator.SetFloat("move", 1f);
                unitAnimator.SetTrigger("isAttacking");
            }

        }

    }

}
