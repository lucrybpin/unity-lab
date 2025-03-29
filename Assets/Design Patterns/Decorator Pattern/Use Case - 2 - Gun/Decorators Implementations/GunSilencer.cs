public class GunSilencer : GunDecorator
{
    public GunSilencer(IGun targetGun) : base(targetGun)
    {
        _targetGun.GetView().EnableSilencer();
    }

    public override string GetName()
    {
        return _targetGun.GetName() + " + Silencer";
    }

    public override GunView GetView()
    {
        return _targetGun.GetView();
    }
}
