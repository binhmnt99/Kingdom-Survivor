using System.Collections;
using System.Collections.Generic;
using Kingdom;
using UnityEngine;

namespace Kingdom
{
    public class UnitActionSystemUI : MonoBehaviour
    {
        [SerializeField] private Transform actionButtonPrefab;
        [SerializeField] private Transform actionButtonContainerTransform;
        private List<ActionButtonUI> actionButtonUIList = new();
        private void Start()
        {
            CreateUnitActionButtons();
        }

        private void CreateUnitActionButtons()
        {
            foreach (Transform buttonTransform in actionButtonContainerTransform)
            {
                Destroy(buttonTransform.gameObject);
            }
            actionButtonUIList.Clear();

            Unit hero = UnitActionSystem.Instance.GetUnit();
            if (!hero.IsEnemy())
            {
                foreach (BaseAction action in hero.GetBaseActionArray())
                {
                    Transform actionButtonTransform = Instantiate(actionButtonPrefab, actionButtonContainerTransform);
                    ActionButtonUI actionButtonUI = actionButtonTransform.GetComponent<ActionButtonUI>();
                    actionButtonUI.SetBaseAction(action);
                    actionButtonUIList.Add(actionButtonUI);
                }
            }
        }
    }
}
