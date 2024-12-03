using System;
using UnityEngine;

public class PlayerInputer : MonoBehaviour
{
    private bool _isPressedFlyKey = false;
    private KeyCode _flyKey = KeyCode.Space;
    private KeyCode _shootKey = KeyCode.F;

    public event Action PressedFly;
    public event Action PressedShoot;

    private void FixedUpdate()
    {
        if (_isPressedFlyKey)
        {
            PressedFly?.Invoke();
            _isPressedFlyKey = false;
        }
    }

    private void Update()
    {
        _isPressedFlyKey |= Input.GetKeyDown(_flyKey);

        if (Input.GetKeyDown(_shootKey))
            PressedShoot?.Invoke();
    }
}
