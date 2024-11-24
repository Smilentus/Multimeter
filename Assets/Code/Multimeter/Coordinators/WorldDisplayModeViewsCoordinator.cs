using TMPro;
using UnityEngine;

namespace Dimasyechka
{
    public class WorldDisplayModeViewsCoordinator : MultimeterModeViewsCoordinator
    {
        [SerializeField]
        private TMP_Text _positionShortTitleTMP;

        [SerializeField]
        private TMP_Text _mainDisplayTMP;


        protected override void OnSetupDisplayModes()
        {
            foreach (MultimeterModeView displayMode in _displayModes)
            {
                displayMode.MainDisplayTMP = _mainDisplayTMP;
                displayMode.Hide();
            }
        }

        protected override void OnPositionProfileChanged()
        {
            _positionShortTitleTMP.text = "";

            HideDisplayModes();

            foreach (MultimeterModeView display in _displayModes)
            {
                if (display.TryShowDisplay(_selectedPositionProfile))
                {
                    if (_positionShortTitleTMP != null)
                    {
                        _positionShortTitleTMP.text = _selectedPositionProfile.ShortTitle;
                    }

                    return;
                }
            }
        }
    }
}
