using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kingdom
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private bool isEnemy;
        private BaseAction[] baseActionArray;

        private void Awake()
        {
            baseActionArray = GetComponents<BaseAction>();
        }

        public bool IsEnemy() => isEnemy;

        public BaseAction[] GetBaseActionArray() => baseActionArray;

        public T GetAction<T>() where T : BaseAction
        {
            foreach (BaseAction action in baseActionArray)
            {
                if (action is T)
                {
                    return (T)action;
                }
            }
            return null;
        }
    }
}
