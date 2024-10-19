using UnityEngine;
using UnityEngine.UIElements;

namespace RAStudio.UIToolkit.Manipulators
{
    /// <summary>
    /// A manipulator that allows dragging of UI elements.
    /// </summary>
    public class DraggableManipulator : PointerManipulator
    {
        private Vector3 m_Start;
        protected bool m_Active;
        private int m_PointerId;

        /// <summary>
        /// Initializes a new instance of the DraggableManipulator class.
        /// </summary>
        public DraggableManipulator()
        {
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
            target.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            target.RegisterCallback<PointerUpEvent>(OnPointerUp);
        }

        /// <summary>
        /// Unregisters callbacks from the manipulator.
        /// </summary>
        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<PointerDownEvent>(OnPointerDown);
            target.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
            target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
        }

        protected void OnPointerDown(PointerDownEvent e)
        {
            if (m_Active)
            {
                e.StopImmediatePropagation();
                return;
            }

            if (CanStartManipulation(e) && IsPointDirectlyOnTarget(e.localPosition))
            {
                m_Start = e.localPosition;
                m_PointerId = e.pointerId;
                m_Active = true;
                target.CapturePointer(m_PointerId);
                e.StopPropagation();
            }
        }

        protected void OnPointerMove(PointerMoveEvent e)
        {
            if (!m_Active || !target.HasPointerCapture(m_PointerId))
                return;

            Vector2 diff = e.localPosition - m_Start;
            target.style.top = target.layout.y + diff.y;
            target.style.left = target.layout.x + diff.x;
            e.StopPropagation();
        }

        protected void OnPointerUp(PointerUpEvent e)
        {
            if (!m_Active || !target.HasPointerCapture(m_PointerId) || !CanStopManipulation(e))
                return;

            m_Active = false;
            target.ReleaseMouse();
            e.StopPropagation();
        }

        private bool IsPointDirectlyOnTarget(Vector2 localPoint)
        {
            // Convert local point to screen space
            Vector2 screenPoint = target.LocalToWorld(localPoint);

            // Perform hit test at the screen point
            VisualElement hitElement = target.panel.Pick(screenPoint);

            // Check if the hit element is exactly our target
            return hitElement == target;
        }
    }
}