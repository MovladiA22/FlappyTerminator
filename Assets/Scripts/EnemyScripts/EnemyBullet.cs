using UnityEngine;

public class EnemyBullet : Bullet, IDeathly
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy) == false &&
            collision.gameObject.TryGetComponent<EnemyBullet>(out EnemyBullet enemyBullet) == false)
            InvokeEvent(this);
    }
}
