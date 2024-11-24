namespace Dimasyechka
{
    public class ACVModeView : MultimeterModeView
    {
        public override void OnUpdate()
        {
            DrawValueWithOverloading(_multimeter.AlternativeCurrentVoltage);
        }
    }
}
