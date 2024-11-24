using UnityEngine;

namespace Dimasyechka
{
    [CreateAssetMenu(fileName = "MultimeterPositionProfile", menuName = "Multimeter/Create New MultimeterPositionProfile")]
    public class MultimeterPositionProfile : ScriptableObject
    {
        [field: SerializeField]
        public string ShortTitle { get; set; }

        [field: SerializeField]
        public MultimeterModeProfile ModeProfile { get; set; }
    }
}
