using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [Header("Left(-1)    None(0)    Right(1)")]
    [SerializeField, Range(-1, 1)] private int _directionX;

    private void Update()
    {
        MoveAlongX();
    }

    private void MoveAlongX()
    {
        transform.Translate(new Vector2(_directionX, 0) * _speed * Time.deltaTime, Space.World);
    }
}
