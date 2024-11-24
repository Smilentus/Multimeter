namespace Dimasyechka
{
    public class AmperageModeView : MultimeterModeView
    {
        public override void OnUpdate()
        {
            DrawValueWithOverloading(_multimeter.Amperage);
        }
    }
}
