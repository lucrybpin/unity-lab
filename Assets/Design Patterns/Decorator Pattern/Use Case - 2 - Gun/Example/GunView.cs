using UnityEngine;

public class GunView : MonoBehaviour
{
    [SerializeField] GameObject _silencer;
    [SerializeField] GameObject _extendedMagazine;

    public void EnableSilencer()
    {
        _silencer.SetActive(true);
    }

    public void DisableSilencer()
    {
        _silencer.SetActive(false);
    }

    public void EnableExtendedMagazine()
    {
        _extendedMagazine.SetActive(true);
    }

    public void DisableExtendedMagazine()
    {
        _extendedMagazine.SetActive(false);
    }
}
