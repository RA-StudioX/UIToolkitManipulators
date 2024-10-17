using UnityEngine;
using UnityEngine.UIElements;

namespace RAStudio.UIToolkit.Manipulators
{
    /// <summary>
    /// A manipulator that detects hover events on UI elements.
    /// </summary>
    public class HoverManipulator : PointerManipulator
    {
        /// <summary>
        /// Event triggered when the pointer enters the target element.
        /// </summary>
        public event System.Action OnHoverEnter;

        /// <summary>
        /// Event triggered when the pointer leaves the target element.
        /// </summary>
        public event System.Action OnHoverExit;

        private bool isHovering = false;

        /// <summary>
        /// Gets a value indicating whether the pointer is currently hovering over the target element.
        /// </summary>
        public bool IsHovering => isHovering;

        /// <summary>
        /// Initializes a new instance of the HoverManipulator class.
        /// </summary>
        public HoverManipulator()
        {
            // No activation filter needed for hover
        }

        /// <summary>
        /// Registers callbacks for the manipulator.
        /// </summary>
        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<PointerEnterEvent>(OnPointerEnter);
            target.RegisterCallback<PointerLeaveEvent>(OnPointerLeave);
        }

        /// <summary>
        /// Unregisters callbacks from the manipulator.
        /// </summary>
        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<PointerEnterEvent>(OnPointerEnter);
            target.UnregisterCallback<PointerLeaveEvent>(OnPointerLeave);
        }

        /// <summary>
        /// Handles the pointer enter event.
        /// </summary>
        /// <param name="evt">The pointer enter event.</param>
        private void OnPointerEnter(PointerEnterEvent evt)
        {
            if (!isHovering)
            {
                isHovering = true;
                OnHoverEnter?.Invoke();
            }
        }

        /// <summary>
        /// Handles the pointer leave event.
        /// </summary>
        /// <param name="evt">The pointer leave event.</param>
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