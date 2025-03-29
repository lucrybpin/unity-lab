using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolPatternUseCaseBullets : MonoBehaviour
{
    [SerializeField] Bullet _bulletPrefab;
    IObjectPool<Bullet> _bulletPool; // 1 - Create The Pool

    void Awake()
    {
        _bulletPool = new ObjectPool<Bullet>(   // 2 - Initialize Pool defining the 3 methods
            OnCreateBullet, 
            OnGet, 
            OnRelease,
            OnDestroyBullet,
            maxSize: 100 // This number is important! The lower it is, more Instantiate will be called (bad performance) and the higher it is
                         // will occupy more of your memory. 
        );
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _bulletPool.Get();
        }
    }

    private Bullet OnCreateBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab); // 4 - Instantiate Normally
        bullet.SetPool(_bulletPool);                // 5 - Delivery a pool reference to the object (check Bullet.cs method SetPool)
        return bullet;
    }

    private void OnGet(Bullet bullet)
    {
        // 6 - OnGet you have to remember to reset the state the object
        bullet.transform.rotation = Quaternion.Euler(new Vector3(Random.Range(0, 360), 90, 90));
        bullet.transform.position = new Vector3(Random.Range(-7f, 7f), Random.Range(-5f, 5f), 0f);
        bullet.gameObject.SetActive(true);
    }

    private void OnRelease(Bullet bullet)
    {
        // 7 - When release is called, instead of Destroying the object, we simply deactivate and keep it in memory
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        // 8 - When there is more than maxSize objects in the scene, the exceding objects will call this method
        // to destroy the exceding object.
        Destroy(bullet.gameObject);
    }
}
