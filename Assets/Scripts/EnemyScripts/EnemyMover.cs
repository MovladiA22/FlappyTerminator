using System.Collections;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;

    private float _positionY;
    private float _target;
    private YieldInstruction _wait;
    private bool _isCoroutineFinished = true;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void OnEnable()
    {
        _target = Random.Range(_minPositionY, _maxPositionY + 1);
    }

    private void Update()
    {
        MoveAlongY();

        if (_isCoroutineFinished)
            StartCoroutine(ChangingTarget());
    }

    private void MoveAlongY()
    {
        var position = transform.position;
        _positionY = Mathf.MoveTowards(position.y, _target, _speed);
        position.y = _positionY;
        transform.position = position;
    }

    private IEnumerator ChangingTarget()
    {
        _isCoroutineFinished = false;
        _target = Random.Range(_minPositionY, _maxPositionY + 1);

        yield return _wait;
        _isCoroutineFinished = true;
    }
}
