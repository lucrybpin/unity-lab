using UnityEngine;

public class RedLight : IState
{
    TrafficLightView _view;
    float _time;
    float _elapsedTime;

    public RedLight(TrafficLightView view, float time)
    {
        _view = view;
        _time = time;
    }

    public void Enter()
    {
        Debug.Log($">>>> Entered Red Light");
        _view.SetRedLight();
    }

    public void Exit()
    {
        Debug.Log($">>>> Exiting Red Light");
    }

    public IState Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _time)
            return new GreenLight(_view, 5.2f);

        Debug.Log($">>>> Executing Red Light");
        return this;
    }
}