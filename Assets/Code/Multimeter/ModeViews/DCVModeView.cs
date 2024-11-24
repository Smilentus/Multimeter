namespace Dimasyechka
{
    public class DCVModeView : MultimeterModeView
    {
        public override void OnUpdate()
        {
            DrawValueWithOverloading(_multimeter.DirectCurrentVoltage);
        }
    }
}
