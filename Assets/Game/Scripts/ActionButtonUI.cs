using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kingdom
{
    public class ActionButtonUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshPro;
        [SerializeField] private Button button;
        [SerializeField] private GameObject selectedGameObject;

        private BaseAction baseAction;

        public void SetBaseAction(BaseAction baseAction)
        {
            this.baseAction = baseAction;
            textMeshPro.text = baseAction.GetActionName().ToUpper();
            button.onClick.AddListener(() => { UnitActionSystem.Instance.SetAction(baseAction); });
        }

        public void UpdateSelectedVisual()
        {
            BaseAction action = UnitActionSystem.Instance.GetAction();
            selectedGameObject.SetActive(action == baseAction);
        }
    }
}
