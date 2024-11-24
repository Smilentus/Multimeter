using UnityEngine;

namespace Dimasyechka
{
    public class ModeSelectorRotatableObject : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private PositionSelector _modeSelector;

        [SerializeField]
        private Transform _rotatableTransform;

        [Header("Settings")]
        [SerializeField]
        private Vector3 _rotationAxis = Vector3.forward;

        [SerializeField]
        private float _animationSpeed = 5f;

        [SerializeField]
        private PositionAngleData[] _positionAngleData;

        private Quaternion _desiredRotation;


        private void FixedUpdate()
        {
            _rotatableTransform.localRotation = Quaternion.Slerp(_rotatableTransform.localRotation, _desiredRotation, Time.fixedDeltaTime * _animationSpeed);
        }


        private void OnEnable()
        {
            if (_modeSelector == null) return;

            _modeSelector.PositionProfileChanged += OnModeProfileChanged;
        }

        private void OnDisable()
        {
            if (_modeSelector == null) return;

            _modeSelector.PositionProfileChanged -= OnModeProfileChanged;
        }


        private void OnModeProfileChanged(MultimeterPositionProfile modeProfile)
        {
            UpdateVisualObject(modeProfile);
        }

        private int GetModeProfileIndex(MultimeterPositionProfile modeProfile)
        {
            for (int i = 0; i < _positionAngleData.Length; i++)
            {
                if (_positionAngleData[i].ModeProfile == modeProfile) return i;
            }

            return 0;
        }


        private void UpdateVisualObject(MultimeterPositionProfile modeProfile)
        {
            int mode = GetModeProfileIndex(modeProfile);

            _desiredRotation = Quaternion.identity * Quaternion.AngleAxis(_positionAngleData[mode].Angle, _rotationAxis);
        }
    }

    [System.Serializable]
    public class PositionAngleData
    {
        public MultimeterPositionProfile ModeProfile;
        public float Angle;
    }
}
