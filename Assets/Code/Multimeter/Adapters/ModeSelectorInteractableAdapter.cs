using UnityEngine;

namespace Dimasyechka
{
    public class ModeSelectorInteractableAdapter : MonoBehaviour
    {
        [SerializeField]
        private PositionSelector _modeSelector;

        [SerializeField]
        private MouseInteractable _mouseInteractable;


        private void OnEnable()
        {
            if (_modeSelector == null || _mouseInteractable == null) return;

            _mouseInteractable.ScrollChanged += OnScrollChanged;
        }

        private void OnDisable()
        {
            if (_modeSelector == null || _mouseInteractable == null) return;

            _mouseInteractable.ScrollChanged -= OnScrollChanged;
        }

        
        private void OnScrollChanged(Vector2 delta)
        {
            if (delta.y < 0)
            {
                _modeSelector.SetPrevPosition();
            }
            
            if (delta.y > 0)
            {
                _modeSelector.SetNextPosition();
            }
        }
    }
}
