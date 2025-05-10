using UnityEngine;

public class SkyController : MonoBehaviour
{
    [field: Range(0, 24)]
    [field: SerializeField] public float Hour               { get; private set; }
    [field: Range(0, 1)]
    [field: SerializeField] public float DaySpeed           { get; private set; }
    [field: SerializeField] public Light Sun                { get; private set; }

    [field: SerializeField] public Gradient SkyColor        { get; private set; }
    [field: SerializeField] public Gradient EquatorColor    { get; private set; }
    [field: SerializeField] public Gradient SunColor        { get; private set; }
    [field: SerializeField] public Gradient FogColor        { get; private set; }
    [field: SerializeField] public Gradient GroundColor     { get; private set; }

    void OnValidate()
    {
        UpdateSky();
    }

    public void UpdateSky()
    {
        Hour += Time.deltaTime * DaySpeed;
        if(Hour > 24) Hour = 0;

        // Sun Rotation
        float sunAngleX         = Mathf.Lerp(-90f, 270f, Hour / 24f);
        Quaternion sunRotation  = Quaternion.Euler(sunAngleX, Sun.transform.rotation.y, Sun.transform.rotation.z);
        Sun.transform.rotation  = sunRotation;

        // Light Settings
        float dayPercentage = Hour / 24f;
        RenderSettings.ambientSkyColor      = SkyColor.Evaluate(dayPercentage);
        RenderSettings.ambientEquatorColor  = EquatorColor.Evaluate(dayPercentage);
        Sun.color                           = SunColor.Evaluate(dayPercentage);
        RenderSettings.fogColor             = FogColor.Evaluate(dayPercentage);
        RenderSettings.ambientGroundColor   = GroundColor.Evaluate(dayPercentage);
    }
}
