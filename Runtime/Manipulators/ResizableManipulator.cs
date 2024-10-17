using UnityEngine;
using UnityEngine.UIElements;

namespace RAStudio.UIToolkit.Manipulators
{
    /// <summary>
    /// A manipulator that allows resizing of UI elements.
    /// </summary>
    public class ResizableManipulator : PointerManipulator
    {
        private Vector3 m_Start;
        protected bool m_Active;
        private int m_PointerId;
        private Vector2 m_StartSize;

        /// <summary>
        /// Initializes a new instance of the ResizableManipulator class.
        /// </summary>
        public ResizableManipulator()
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

            if (CanStartManipulation(e))
            {
                m_Start = e.localPosition;
                m_StartSize = target.layout.size;
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
            target.style.width = m_StartSize.x + diff.x;
            target.style.height = m_StartSize.y + diff.y;
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
    }
}