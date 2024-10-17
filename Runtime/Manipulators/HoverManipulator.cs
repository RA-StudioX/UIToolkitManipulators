using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

namespace RAStudio.UIToolkit.Manipulators
{
    public class HoverManipulator : PointerManipulator
    {
        public event System.Action OnHoverEnter;
        public event System.Action OnHoverExit;

        private bool isHovering = false;
        public bool IsHovering => isHovering;

        public HoverManipulator()
        {
            // No activation filter needed for hover
        }

        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<PointerEnterEvent>(OnPointerEnter);
            target.RegisterCallback<PointerLeaveEvent>(OnPointerLeave);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<PointerEnterEvent>(OnPointerEnter);
            target.UnregisterCallback<PointerLeaveEvent>(OnPointerLeave);
        }

        private void OnPointerEnter(PointerEnterEvent evt)
        {
            if (!isHovering)
            {
                isHovering = true;
                OnHoverEnter?.Invoke();
            }
        }

        private void OnPointerLeave(PointerLeaveEvent evt)
        {
            if (isHovering)
            {
                isHovering = false;
                OnHoverExit?.Invoke();
            }
        }
    }
}
