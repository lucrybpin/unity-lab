using UnityEngine;

public class TrafficLightView : MonoBehaviour
{
    [SerializeField] Renderer _redLight;
    [SerializeField] Renderer _yellowLight;
    [SerializeField] Renderer _greenLight;

    [SerializeField] Color _red;
    [SerializeField] Color _yellow;
    [SerializeField] Color _green;

    public void SetRedLight()
    {
        _redLight.material.color = _red;
        _yellowLight.material.color = Color.gray;
        _greenLight.material.color = Color.gray;
    }

    public void SetYellowLight()
    {
        _redLight.material.color = Color.gray;
        _yellowLight.material.color = _yellow;
        _greenLight.material.color = Color.gray;
    }

    public void SetGreenLight()
    {
        _redLight.material.color = Color.gray;
        _yellowLight.material.color = Color.gray;
        _greenLight.material.color = _green;
    }
}
