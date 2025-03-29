
public abstract class GunDecorator : IGun
{
    protected IGun _targetGun;

    public GunDecorator(IGun targetGun)
    {
        _targetGun = targetGun;
    }

    public abstract string GetName();

    public abstract GunView GetView();
}
