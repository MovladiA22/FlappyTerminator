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
        if (transform.position.IsEnoughClose(_startedPosition, _maxDistance) == false)
            Lost?.Invoke(this);
    }

    protected void InvokeEventCollided(Bullet bullet) =>
        Collided?.Invoke(bullet);
}
