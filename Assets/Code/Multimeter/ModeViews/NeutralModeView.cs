namespace Dimasyechka
{
    public class NeutralModeView : MultimeterModeView
    {
        public override void OnUpdate()
        {
            _mainDisplayTMP.text = 0.ToString("f2"); // ��� � ���� ���� ;) ???
        }

        public override void OnHide() 
        {
            _mainDisplayTMP.text = "";
        }
    }
}
