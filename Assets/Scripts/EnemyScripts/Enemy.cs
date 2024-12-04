using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private Transform _spawnZone;

    public event Action<Enemy> Died;
    public event Action<Enemy> Lost;

    private void Update()
    {
        if (transform.position.IsEnoughClose(_spawnZone.position, _maxDistance) == false)
            Lost?.Invoke(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerBullet>(out PlayerBullet playerBullet))
            Died?.Invoke(this);
    }
}
