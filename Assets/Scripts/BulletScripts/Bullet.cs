using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _maxDistance;

    private Vector2 _startedPosition;

    public event Action<Bullet> Collided;
    public event Action<Bullet> Lost;

    private void OnEnable()
    {
        _startedPosition = transform.position;
    }

    private void Update()
    {
        if (Vector2.Distance(_startedPosition, transform.position) > _maxDistance)
            Lost?.Invoke(this);
    }

    protected void InvokeEvent(Bullet bullet) =>
        Collided?.Invoke(bullet);
}
