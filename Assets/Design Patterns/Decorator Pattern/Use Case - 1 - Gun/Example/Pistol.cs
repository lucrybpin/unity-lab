
public class Pistol : IGun
{
    GunView _view;

    public Pistol(GunView view)
    {
        _view = view;
    }

    public string GetName()
    {
        return "Pistol";
    }

    public GunView GetView()
    {
        return _view;
    }

}
