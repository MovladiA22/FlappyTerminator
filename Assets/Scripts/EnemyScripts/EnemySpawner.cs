using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _spawnDelay;

    private void Awake()
    {
        foreach (Enemy enemy in _enemies)
            enemy.gameObject.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(Spawning());
    }
    
    private void Spawn(int index)
    {
        _enemies[index].gameObject.SetActive(true);

        _enemies[index].Died += Release;
    }

    private void Release(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);

        enemy.Died -= Release;
    }

    private IEnumerator Spawning()
    {
        var wait = new WaitForSeconds(_spawnDelay);
        bool _isWork = true;

        yield return wait;

        while (_isWork)
        {
            for (int i = 0; i < _enemies.Length; i++)
            {
                if (_enemies[i].gameObject.activeSelf == false)
                {
                    Spawn(i);
                    break;
                }
            }

            yield return wait;
        }
    }
}
