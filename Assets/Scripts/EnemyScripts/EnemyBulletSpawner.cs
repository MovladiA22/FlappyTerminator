using System.Collections;
using UnityEngine;

public class EnemyBulletSpawner : BulletSpawner
{
    [SerializeField] private float _delay;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(Spawning());
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine( _coroutine );
    }

    private IEnumerator Spawning()
    {
        var wait = new WaitForSeconds(_delay);
        bool isWork = true;
        
        while (isWork)
        {
            GetBullet();

            yield return wait;
        }
    }
}
