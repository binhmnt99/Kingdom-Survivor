using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public abstract class BaseAction : MonoBehaviour
    {
        protected Unit unit;
        [SerializeField] protected Animator unitAnimator;
        protected virtual void Awake()
        {
            unit = GetComponent<Unit>();
            unitAnimator = GetComponent<Animator>();
        }

        public abstract string GetActionName();
        public abstract void TakeAction();
    }
}

