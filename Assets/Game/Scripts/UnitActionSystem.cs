using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public class UnitActionSystem : Singleton<UnitActionSystem>
    {
        [SerializeField] private Unit unit;
        [SerializeField] private BaseAction action;

        public event EventHandler OnActionChanged;

        private void Start()
        {
            if (GameObject.FindAnyObjectByType<Unit>().IsEnemy() == false)
            {
                unit = GameObject.FindAnyObjectByType<Unit>();
            }
            BaseAction firstAction = unit.GetBaseActionArray()[0];
        }

        public Unit GetUnit() => unit;
        public BaseAction GetAction() => action;

        public void SetAction(BaseAction baseAction)
        {
            action = baseAction;
            OnActionChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

