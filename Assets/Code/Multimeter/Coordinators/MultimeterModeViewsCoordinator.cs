using System.Collections.Generic;
using UnityEngine;

namespace Dimasyechka
{
    public class MultimeterModeViewsCoordinator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        protected PositionSelector _positionSelector;

        [SerializeField]
        protected Multimeter _multimeter;


        [Header("Settings")]
        [SerializeField]
        protected List<MultimeterModeView> _displayModes = new List<MultimeterModeView>();


        protected MultimeterPositionProfile _selectedPositionProfile;


        private void Awake()
        {
            SetupDisplayModes();
        }


        private void OnEnable()
        {
            if (_positionSelector == null) return;

            _positionSelector.PositionProfileChanged += OnPositionProfileChanged;
        }

        private void OnDisable()
        {
            if (_positionSelector == null) return;

            _positionSelector.PositionProfileChanged -= OnPositionProfileChanged;
        }


        private void SetupDisplayModes()
        {
            foreach (MultimeterModeView displayMode in _displayModes)
            {
                displayMode.Multimeter = _multimeter;
            }

            OnSetupDisplayModes();
        }

        protected void HideDisplayModes()
        {
            foreach (MultimeterModeView displayMode in _displayModes)
            {
                displayMode.Hide();
            }
        }

        private void OnPositionProfileChanged(MultimeterPositionProfile positionProfile)
        {
            _selectedPositionProfile = positionProfile;

            OnPositionProfileChanged();
        }


        protected virtual void OnSetupDisplayModes() { }
        protected virtual void OnPositionProfileChanged() { }
    }
}
