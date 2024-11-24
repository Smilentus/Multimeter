namespace Dimasyechka
{
    public class ResistanceModeView : MultimeterModeView
    {
        public override void OnUpdate()
        {
            DrawValueWithOverloading(_multimeter.Resistance);
        }
    }
}
