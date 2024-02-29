using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public class FireBeamAction : BaseAction
    {
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

}
