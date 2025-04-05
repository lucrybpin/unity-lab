using UnityEngine;

public class YellowLight : IState
{
    TrafficLightView _view;
    float _time;
    float _elapsedTime;

    public YellowLight(TrafficLightView view, float time)
    {
        _view = view;
        _time = time;
    }

    public void Enter()
    {
        Debug.Log($">>>> Entered Yellow Light");
        _view.SetYellowLight();
    }

    public void Exit()
    {
        Debug.Log($">>>> Exiting Yellow Light");
    }

    public IState Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _time)
            return new RedLight(_view, 7f);

        Debug.Log($">>>> Executing Yellow Light");
        return this;
    }
}