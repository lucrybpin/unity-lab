using UnityEngine;

public class StatePatternTrafficLight : MonoBehaviour
{
    [SerializeField] TrafficLightView _view;

    IState _currentState;

    void Start()
    {
        _currentState = new GreenLight(_view, 7f);
        _currentState.Enter();
    }

    void Update()
    {
        IState _newState = _currentState.Update();

        if(_newState != _currentState)
        {
            _currentState.Exit();
            _newState.Enter();
            _currentState = _newState;
        }
    }


}

