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
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => ActionOnRelease(obj),
            actionOnDestroy: (obj) => DestroyObj(obj),
            collectionCheck: false,
            defaultCapacity: _poolCapacity,
            maxSize: _maxSize);
    }

    protected void GetBullet()
    {
        _pool.Get();
    }

    protected void ReleaseObj(Bullet obj)
    {
        _pool.Release(obj);
    }

    protected virtual Bullet Create()
    {
        var copy = Instantiate(_prefab, _spawnZone.position, Quaternion.identity);

        return copy;
    }

    protected virtual void ActionOnGet(Bullet obj)
    {
        obj.transform.position = _spawnZone.position;
        obj.gameObject.SetActive(true);

        obj.Collided += ReleaseObj;
        obj.Lost += ReleaseObj;
    }

    protected virtual void ActionOnRelease(Bullet obj)
    {
        obj.gameObject.SetActive(false);

        obj.Collided -= ReleaseObj;
        obj.Lost -= ReleaseObj;
    }

    private void DestroyObj(Bullet obj)
    {
        Destroy(obj.gameObject);
    }
}
