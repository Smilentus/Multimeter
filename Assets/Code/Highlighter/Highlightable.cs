using UnityEngine;

namespace Dimasyechka
{
    public abstract class Highlightable : MonoBehaviour
    {
        public void StartHighlight()
        {
            OnHighlightStarted();
        }

        public void EndHighlight()
        {
            OnHighlightEnded();
        }


        protected abstract void OnHighlightStarted();
        protected abstract void OnHighlightEnded();
    }
}
