using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public abstract class BaseAction : MonoBehaviour
    {
        protected Unit unit;
        protected virtual void Awake()
        {
            unit = GetComponent<Unit>();
        }

        public abstract string GetActionName();
        public abstract void TakeAction();
    }
}

