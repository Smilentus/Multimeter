using UnityEngine;

namespace Dimasyechka
{
    [CreateAssetMenu(fileName = "MultimeterPositionProfileWithValue", menuName = "Multimeter/Create New MultimeterPositionProfileWithValue")]
    public class MultimeterPositionProfileWithValue : MultimeterPositionProfile
    {
        [field: SerializeField]
        public float Value { get; set; }
    }
}
