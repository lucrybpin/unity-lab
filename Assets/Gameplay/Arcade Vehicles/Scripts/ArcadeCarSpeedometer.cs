using TMPro;
using UnityEngine;

public class ArcadeVehicleSpeedometer : MonoBehaviour
{
    [field: SerializeField] public TMP_Text VelocityText        { get; private set; }
    [field: SerializeField] public IArcadeVehicle Target        { get; private set; } // Não dá pra serializar, criar um gamecontroller e chamar um Init

    public void Setup(IArcadeVehicle vehicle)
    {
        Target = vehicle;
    }

    public void OnLateUpdate()
    {
        float speedKPH = Target.Rigidbody.linearVelocity.magnitude * 3.6f;
        VelocityText.text = $"{speedKPH: 0} KM/h";
    }
}
