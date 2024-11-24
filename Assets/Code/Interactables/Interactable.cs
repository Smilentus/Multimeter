using System;
using UnityEngine;

namespace Dimasyechka
{
    public class Interactable : MonoBehaviour
    {
        public event Action HoverStarted = null;
        public event Action HoverEnded = null;


        [SerializeField]
        private Highlightable _highlightable;


        public bool CanInteract { get; set; } = true;


        public void StartHover()
        {
            if (!CanInteract) return;

            if (_highlightable != null)
            {
                _highlightable.StartHighlight();
            }

            OnHoverStarted();
            HoverStarted?.Invoke();
        }

        public void EndHover()
        {
            if (!CanInteract) return;

            if (_highlightable != null)
            {
                _highlightable.EndHighlight();
            }

            OnHoverEnded();
            HoverEnded?.Invoke();
        }


        protected virtual void OnHoverStarted() { }
        protected virtual void OnHoverEnded() { }
    }
}
