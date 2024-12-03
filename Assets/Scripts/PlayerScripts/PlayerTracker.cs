using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        var position = transform.position;
        position.x = player.transform.position.x + _xOffset;
        transform.position = position;
    }
}
