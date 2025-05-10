using TMPro;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
    [field: Range(0, 24)]
    [field: SerializeField] public float Hour                   { get; private set; }

    [field: Range(0, 1)]
    [field: SerializeField] public float DaySpeed               { get; private set; }

    [field: SerializeField] public GameObject HoursPointer      { get; private set; }
    [field: SerializeField] public GameObject MinutesPointer    { get; private set; }
    [field: SerializeField] public GameObject SecondsPointer    { get; private set; }
    [field: SerializeField] public TMP_Text DigitalClock        { get; private set; }

    float hourPointerAngularSpeed;
    float minutesPointerAngularSpeed;
    float secondsPointerAngularSpeed;

    void Update()
    {
        Hour += Time.deltaTime * DaySpeed;
        if(Hour > 24) Hour = 0;

        // Speed = Space / Time
        // Lets fix time as 1 hour, how much degrees
        // each pointer rotates every one hour?

        // Hour:    360 / 12           = 30 degrees
        // Minutes: 360 degrees
        // Seconds: 60 * 360 degrees

        // Analog Clock
        hourPointerAngularSpeed     = 360 / 12 * DaySpeed;
        minutesPointerAngularSpeed  = 360 * DaySpeed;
        secondsPointerAngularSpeed  = 60 * 360 * DaySpeed;

        HoursPointer.transform.Rotate(new Vector3(0f,0f, -hourPointerAngularSpeed * Time.deltaTime));
        MinutesPointer.transform.Rotate(new Vector3(0f,0f, -minutesPointerAngularSpeed * Time.deltaTime));
        SecondsPointer.transform.Rotate(new Vector3(0f,0f, -secondsPointerAngularSpeed * Time.deltaTime));

        // Digital Clock
        int hours = Mathf.FloorToInt(Hour);
        float remainingHours = Hour - hours;
        int minutes = Mathf.FloorToInt(remainingHours * 60f);
        float remainingMinutes = (remainingHours * 60f) - minutes;
        int seconds = Mathf.FloorToInt(remainingMinutes * 60f);
        DigitalClock.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
