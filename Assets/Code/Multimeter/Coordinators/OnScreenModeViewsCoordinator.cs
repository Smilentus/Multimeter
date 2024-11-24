using UnityEngine;

namespace Dimasyechka
{
    public class OnScreenModeViewsCoordinator : MultimeterModeViewsCoordinator
    {
        [SerializeField]
        private bool _showEnerythingAtOnce = true;


        protected override void OnSetupDisplayModes()
        {
            HideDisplayModes();
            ClearLabels();
        }

        protected override void OnPositionProfileChanged()
        {
            HideDisplayModes();
            ClearLabels();

            if (_showEnerythingAtOnce)
            {
                foreach (MultimeterModeView display in _displayModes)
                {
                    display.Show();
                }
            }
            else
            {
                foreach (MultimeterModeView display in _displayModes)
                {
                    if (display.TryShowDisplay(_selectedPositionProfile)) { return; }
                }
            }
        }

        private void ClearLabels()
        {
            foreach (MultimeterModeView display in _displayModes)
            {
                display.DrawValue(0);
            }
        }
    }
}
