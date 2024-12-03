using UnityEngine;

public class PlayerBullet : Bullet
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player) == false &&
            collision.gameObject.TryGetComponent<PlayerBullet>(out PlayerBullet playerBullet) == false)
            InvokeEvent(this);
    }
}
