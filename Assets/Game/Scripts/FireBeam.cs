using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kingdom;

public class FireBeam : BaseAction
{
    [SerializeField] private Animator unitAnimator;
    public override string GetActionName() => "MagicSkill";
    public override void TakeAction()
    {
        unitAnimator.SetBool("isFireBeam", true);
        StartCoroutine(LifeTime(3f));
    }
    private IEnumerator LifeTime(float time)
    {
        yield return new WaitForSeconds(time);
        unitAnimator.SetBool("isFireBeam", false);
    }
}
