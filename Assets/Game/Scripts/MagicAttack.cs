using System.Collections;
using System.Collections.Generic;
using Kingdom;
using UnityEngine;

public class MagicAttack : BaseAction
{
    [SerializeField] private Animator unitAnimator;
    public override string GetActionName() => "MagicShot";
    public override void TakeAction() 
    {
        unitAnimator.SetTrigger("isAttacking");
    }

}
