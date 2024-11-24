using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dimasyechka
{
    public class PositionSelector : MonoBehaviour
    {
        public event Action<int> PositionChanged = null;
        public event Action<MultimeterPositionProfile> PositionProfileChanged = null;

        [SerializeField]
        private List<MultimeterPositionProfile> _multimeterPositions = new List<MultimeterPositionProfile>();

        public int AvailablePositionsCount => _multimeterPositions.Count;

        private MultimeterPositionProfile _selectedPositionProfile;
        public MultimeterPositionProfile SelectedPositionProfile => _selectedPositionProfile;

        private int _selectedPosition = 0;
        public int SelectedPosition => _selectedPosition;


        private void Start()
        {
            SetPosition(0);
        }


        public void SetPosition(int position)
        {
            _selectedPosition = position;

            ClampPositions();

            _selectedPositionProfile = _multimeterPositions[_selectedPosition];

            PositionChanged?.Invoke(_selectedPosition);
            PositionProfileChanged?.Invoke(_selectedPositionProfile);
        }
        
        public void SetNextPosition()
        {
            SetPosition(++_selectedPosition);
        }

        public void SetPrevPosition()
        {
            SetPosition(--_selectedPosition);
        }

        private void ClampPositions()
        {
            if (_selectedPosition >= AvailablePositionsCount)
            {
                _selectedPosition = 0;
            }
            
            if (_selectedPosition < 0)
            {
                _selectedPosition = AvailablePositionsCount - 1;
            }
        }
    }
}
