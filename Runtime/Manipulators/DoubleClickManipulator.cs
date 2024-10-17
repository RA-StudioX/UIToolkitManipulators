using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace RAStudio.UIToolkit.Manipulators
{
    /// <summary>
    /// A manipulator that detects double-click events on UI elements.
    /// </summary>
    public class DoubleClickManipulator : PointerManipulator
    {
        private Action m_DoubleClickAction;
        private float m_LastClickTime;
        private const float DoubleClickTimeThreshold = 0.3f; // Adjust this value to change the double-click speed sensitivity

        /// <summary>
        /// Initializes a new instance of the DoubleClickManipulator class.
        /// </summary>
        /// <param name="doubleClickAction">The action to perform on double-click.</param>
        public DoubleClickManipulator(Action doubleClickAction)
        {
            m_DoubleClickAction = doubleClickAction;
            m_LastClickTime = 0f;
            activators.Add(new ManipulatorActivationFilter { button = MouseButton.LeftMouse });
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

        private void OnPointerDown(PointerDownEvent evt)
        {
            if (CanStartManipulation(evt))
            {
                evt.StopPropagation();
            }
        }

        private void OnPointerUp(PointerUpEvent evt)
        {
            if (CanStopManipulation(evt))
            {
                float currentTime = Time.realtimeSinceStartup;
                if (currentTime - m_LastClickTime < DoubleClickTimeThreshold)
                {
                    m_DoubleClickAction?.Invoke();
                    m_LastClickTime = 0f; // Reset the timer after a successful double-click
                }
                else
                {
                    m_LastClickTime = currentTime;
                }
                evt.StopPropagation();
            }
        }
    }
}