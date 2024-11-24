using UnityEngine;

namespace Dimasyechka
{
    [CreateAssetMenu(fileName = "MultimeterModeProfile", menuName = "Multimeter/Create New MultimeterModeProfile")]
    public class MultimeterModeProfile : ScriptableObject
    {
        [field: SerializeField]
        public string ModeTitle { get; set; }

        [SerializeField]
        [TextArea(5, 10)]
        private string _modeDescription;
        public string ModeDescription => _modeDescription;
    }
}
