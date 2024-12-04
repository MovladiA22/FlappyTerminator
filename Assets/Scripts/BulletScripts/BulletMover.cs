using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        MoveAlongX();
    }

    private void MoveAlongX()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime, Space.Self);
    }
}
