using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _spawnZone;
    [SerializeField] private int _poolCapacity = 10;
    [SerializeField] private int _maxSize = 10;

    private ObjectPool<Bullet> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>
            (createFunc: () => Create(),
            actionOnGet: (bullet) => ActivateObj(bullet),
            actionOnRelease: (bullet) => DeactivateObj(bullet),
            actionOnDestroy: (bullet) => DestroyObj(bullet),
            collectionCheck: false,
            defaultCapacity: _poolCapacity,
            maxSize: _maxSize);
    }

    protected void GetBullet()
    {
        _pool.Get();
    }

    protected void ReleaseObj(Bullet bullet)
    {
        _pool.Release(bullet);
    }

    protected virtual Bullet Create()
    {
        return Instantiate(_prefab, _spawnZone.position, _spawnZone.rotation);
    }

    protected virtual void ActivateObj(Bullet bullet)
    {
        bullet.transform.position = _spawnZone.position;
        bullet.transform.rotation = _spawnZone.rotation;
        bullet.gameObject.SetActive(true);

        bullet.Collided += ReleaseObj;
        bullet.Lost += ReleaseObj;
    }

    protected virtual void DeactivateObj(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);

        bullet.Collided -= ReleaseObj;
        bullet.Lost -= ReleaseObj;
    }

    private void DestroyObj(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }
}
