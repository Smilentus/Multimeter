using System;
using UnityEngine;

namespace Dimasyechka
{
    public class MouseInteractable : Interactable
    {
        public event Action LeftMouseButtonPressed = null;
        public event Action RightMouseButtonPressed = null;
        public event Action<Vector2> ScrollChanged = null;


        public void PressLeftMouseButton()
        {
            OnLeftMouseButtonPressed();
            LeftMouseButtonPressed?.Invoke();
        }

        public void PressRightMouseButton()
        {
            OnRightMouseButtonPressed();
            RightMouseButtonPressed?.Invoke();
        }

        public void ChangeScroll(Vector2 delta)
        {
            OnScrollChanged(delta);
            ScrollChanged?.Invoke(delta);
        }


        protected virtual void OnLeftMouseButtonPressed() { }
        protected virtual void OnRightMouseButtonPressed() { }  
        protected virtual void OnScrollChanged(Vector2 delta) { }
    }
}
