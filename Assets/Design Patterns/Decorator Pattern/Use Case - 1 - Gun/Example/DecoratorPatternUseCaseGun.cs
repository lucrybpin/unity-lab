using UnityEngine;

public class DecoratorPatternUseCaseGun : MonoBehaviour
{
    [SerializeField] private GunView _gunView;
    [SerializeField] private bool _silencer;
    [SerializeField] private bool _extendedMagazine;

    IGun gun;


    void Start()
    {
        gun = new Pistol(_gunView);

        if (_silencer)          gun = new GunSilencer(gun);
        if (_extendedMagazine)  gun = new GunExtendedMagazine(gun);

        Debug.Log($">>>> Gun: {gun.GetName()}");

        // Problem: How do you remove decorators?
    }
}
