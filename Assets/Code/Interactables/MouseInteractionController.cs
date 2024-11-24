using UnityEngine;

namespace Dimasyechka
{
    public class MouseInteractionController : MonoBehaviour
    {
        private MouseInteractable _lastSelectedInteractable = null;


        private void Update()
        {
            FindInteractable();
            ProcessInput();
        }


        private void FindInteractable()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 1000))
            {
                if (hit.collider.TryGetComponent<MouseInteractable>(out MouseInteractable interactable))
                {
                    if (_lastSelectedInteractable == interactable) { return; }

                    _lastSelectedInteractable?.EndHover();
                    _lastSelectedInteractable = interactable;
                    _lastSelectedInteractable.StartHover();
                }
                else
                {
                    _lastSelectedInteractable?.EndHover();
                    _lastSelectedInteractable = null;
                }
            }
            else
            {
                _lastSelectedInteractable?.EndHover();
                _lastSelectedInteractable = null;
            }
        }

        private void ProcessInput()
        {
            if (_lastSelectedInteractable == null) return;

            if (Input.GetMouseButtonDown(0))
            {
                SendLeftMouseButton();
            }

            if (Input.GetMouseButtonDown(1))
            {
                SendRightMouseButton();
            }

            SendScrollData(Input.mouseScrollDelta);
        }


        private void SendLeftMouseButton()
        {
            _lastSelectedInteractable?.PressLeftMouseButton();
        }

        private void SendRightMouseButton()
        {
            _lastSelectedInteractable?.PressRightMouseButton();
        }

        private void SendScrollData(Vector2 delta)
        {
            _lastSelectedInteractable?.ChangeScroll(delta);
        }
    }
}
