using TMPro;
using UnityEngine;

namespace Dimasyechka
{
    public class MultimeterModeView : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        protected MultimeterModeProfile _referencedModeProfile;

        [Header("Extra")]
        [SerializeField]
        protected GameObject[] _toggleables;

        [SerializeField]
        protected TMP_Text _mainDisplayTMP;

        [Header("Settings")]
        [SerializeField]
        protected string _mainDisplayFormat = "f2";

        [SerializeField]
        protected bool _useOverloading = false;


        public TMP_Text MainDisplayTMP { get => _mainDisplayTMP; set => _mainDisplayTMP = value; }
        public Multimeter Multimeter { get => _multimeter; set => _multimeter = value; }


        protected Multimeter _multimeter;
        protected MultimeterPositionProfile _selectedPositionProfile;


        private bool _isEnabled = false;


        private void Update()
        {
            if (!_isEnabled) return;

            OnUpdate();
        }


        public bool TryShowDisplay(MultimeterPositionProfile selectedPositionProfile)
        {
            if (_referencedModeProfile.Equals(selectedPositionProfile.ModeProfile))
            {
                _selectedPositionProfile = selectedPositionProfile;

                Show();

                return true;
            }
            else
            {
                _selectedPositionProfile = null;

                Hide();

                return false;
            }
        }

        public void DrawValueWithOverloading(float value)
        {
            if (IsOverload(value))
            {
                if (_mainDisplayTMP == null) return;

                _mainDisplayTMP.text = "OVERLOAD";
            }
            else
            {
                DrawValue(value);
            }
        }

        public void DrawValue(float value)
        {
            if (_mainDisplayTMP == null) return;

            _mainDisplayTMP.text = value.ToString(_mainDisplayFormat);
        }

        public bool IsOverload(float value)
        {
            if (!_useOverloading) return false;

            if (_selectedPositionProfile is MultimeterPositionProfileWithValue)
            {
                MultimeterPositionProfileWithValue valueProfile = _selectedPositionProfile as MultimeterPositionProfileWithValue;

                return value > valueProfile.Value;
            }
            else
            {
                return false;
            }
        }


        public void Show()
        {
            _isEnabled = true;

            foreach (GameObject toggleable in _toggleables)
            {
                if (toggleable != null)
                {
                    toggleable.SetActive(true);
                }
            }

            OnShow();
        }

        public void Hide()
        {
            _isEnabled = false;

            foreach (GameObject toggleable in _toggleables)
            {
                if (toggleable != null)
                {
                    toggleable.SetActive(false);
                }
            }

            OnHide();
        }


        public virtual void OnShow() { }
        public virtual void OnUpdate() { }
        public virtual void OnHide() { }
    }
}