using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    IObjectPool<Bullet> _bulletPool;

    public void SetPool(IObjectPool<Bullet> pool)
    {
        _bulletPool = pool;
    }

    void OnEnable()
    {
        Invoke("OnDie", 7f);   // Just providing a way to "Destroy" object. For example when the bullet hit a target
    }

    void Update()
    {
        transform.Translate(Vector3.forward * 0.1f * Time.deltaTime);
    }

    void OnDie()
    {
        _bulletPool.Release(this);  // You must call the Release
    }
}
