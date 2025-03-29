public class GunExtendedMagazine : GunDecorator
{
    public GunExtendedMagazine(IGun targetGun) : base(targetGun)
    {
        _targetGun.GetView().EnableExtendedMagazine();
    }

    public override string GetName()
    {
        return _targetGun.GetName() + " + Extended Magazine";
    }

    public override GunView GetView()
    {
        return _targetGun.GetView();
    }
}
