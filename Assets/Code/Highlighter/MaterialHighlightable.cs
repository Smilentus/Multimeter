using UnityEngine;

namespace Dimasyechka
{
    /*
        ����������� ������� � ������ ��������� ����� ��������� ����� ��������� ��������� (��� ������������)
     */
    public class MaterialHighlightable : Highlightable
    {
        private const string MaterialColorName = "_Color";


        [SerializeField]
        private HighlightProfile _highlightProfile;


        [SerializeField]
        private Renderer[] _renderers;


        [ContextMenu("On")]
        protected override void OnHighlightStarted()
        {
            if (!Application.isPlaying)
            {
                Debug.LogWarning($"����� � PlayMode ����� ����������");
                return;
            }

            SetColorToRenderers(_highlightProfile.HighlightColor);
        }

        [ContextMenu("Off")]
        protected override void OnHighlightEnded()
        {
            if (!Application.isPlaying)
            {
                Debug.LogWarning($"����� � PlayMode ����� ����������");
                return;
            }

            ClearRenderers();
        }


        private void SetColorToRenderers(Color color)
        {
            foreach (Renderer renderer in _renderers)
            {
                MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();

                renderer.GetPropertyBlock(materialPropertyBlock);

                materialPropertyBlock.SetColor(MaterialColorName, color);

                renderer.SetPropertyBlock(materialPropertyBlock);
            }
        }

        private void ClearRenderers()
        {
            foreach (Renderer renderer in _renderers)
            {
                if (renderer == null) continue;

                MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();

                renderer.GetPropertyBlock(materialPropertyBlock);

                materialPropertyBlock.Clear();

                renderer.SetPropertyBlock(materialPropertyBlock);
            }
        }
    }
}
