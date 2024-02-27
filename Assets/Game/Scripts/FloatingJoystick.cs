using UnityEngine;

namespace Kingdom
{
    [RequireComponent(typeof(RectTransform))]
    [DisallowMultipleComponent]
    public class FloatingJoystick : MonoBehaviour
    {
        [HideInInspector]
        public RectTransform RectTransform;
        public RectTransform Knob;

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
        }
    }

}