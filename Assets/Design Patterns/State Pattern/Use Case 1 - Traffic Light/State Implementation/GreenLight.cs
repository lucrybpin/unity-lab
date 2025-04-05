using UnityEngine;

public class GreenLight : IState
{
    TrafficLightView _view;
    float _time;
    float _elapsedTime;

    public GreenLight(TrafficLightView view, float time)
    {
        _view = view;
        _time = time;
    }

    public void Enter()
    {
        Debug.Log($">>>> Entered Green Light");
        _view.SetGreenLight();
    }

    public void Exit()
    {
        Debug.Log($">>>> Exiting Green Light");
    }

    public IState Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _time)
            return new YellowLight(_view, 2.5f);

        Debug.Log($">>>> Executing Green Light");
        return this;
    }
}
