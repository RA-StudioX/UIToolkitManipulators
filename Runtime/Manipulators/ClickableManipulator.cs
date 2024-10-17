using System;
using UnityEngine.UIElements;

namespace RAStudio.UIToolkit.Manipulators
{
    /// <summary>
    /// A manipulator that handles click events on UI elements.
    /// </summary>
    public class ClickableManipulator : PointerManipulator
    {
        private Action m_ClickAction;
        protected bool m_Active;
        private int m_PointerId;

        /// <summary>
        /// Initializes a new instance of the ClickableManipulator class.
        /// </summary>
        /// <param name="clickAction">The action to perform when clicked.</param>
        public ClickableManipulator(Action clickAction)
        {
            m_ClickAction = clickAction;
            m_PointerId = -1;
            activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
            m_Active = false;
        }

        /// <summary>
        /// Registers callbacks for the manipulator.
        /// </summary>
        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<PointerDownEvent>(OnPointerDown);
            target.RegisterCallback<PointerUpEvent>(OnPointerUp);
        }

        /// <summary>
        /// Unregisters callbacks from the manipulator.
        /// </summary>
        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<PointerDownEvent>(OnPointerDown);
            target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
        }

        protected void OnPointerDown(PointerDownEvent e)
        {
            if (m_Active)
            {
                e.StopImmediatePropagation();
                return;
            }

            if (CanStartManipulation(e))
            {
                m_PointerId = e.pointerId;
                m_Active = true;
                target.CapturePointer(m_PointerId);
                e.StopPropagation();
            }
        }

        protected void OnPointerUp(PointerUpEvent e)
        {
            if (!m_Active || !target.HasPointerCapture(m_PointerId) || !CanStopManipulation(e))
                return;

            m_Active = false;
            target.ReleaseMouse();
            m_ClickAction?.Invoke();
            e.StopPropagation();
        }
    }
}