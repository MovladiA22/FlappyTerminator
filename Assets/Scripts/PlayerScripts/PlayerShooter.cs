using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private PlayerInputer _inputer;
    [SerializeField] private PlayerBulletSpawner _bulletSpawner;

    private void OnEnable()
    {
        _inputer.PressedShoot += Shoot;
    }

    private void OnDisable()
    {
        _inputer.PressedShoot -= Shoot;
    }

    private void Shoot()
    {
        _bulletSpawner.Spawn();
    }
}
