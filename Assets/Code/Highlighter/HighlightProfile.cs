using UnityEngine;

namespace Dimasyechka
{
    [CreateAssetMenu(fileName = "Highlight Profile", menuName = "Create Highlight Profile")]
    public class HighlightProfile : ScriptableObject
    {
        [field: SerializeField]
        public Color HighlightColor { get; set; }
    }
}
