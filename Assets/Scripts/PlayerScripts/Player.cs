using System;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCollisionHandler))]
public class Player : MonoBehaviour
{
    private PlayerCollisionHandler _collisionHandler;
    private PlayerMover _mover;

    public event Action Died;

    private void Awake()
    {
        _collisionHandler = GetComponent<PlayerCollisionHandler>();
        _mover = GetComponent<PlayerMover>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(Collider2D collider)
    {
        if (collider.TryGetComponent<IDeathly>(out IDeathly deathly))
            Died?.Invoke();
    }
}
