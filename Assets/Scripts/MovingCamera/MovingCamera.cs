using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    [SerializeField] private float _finishCoordinates;
    [SerializeField] private Vector2 _endPosition;
    [SerializeField] private Transform _player;
    [SerializeField] private Camera _mainCamera;

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(transform.position.x >= _endPosition.x) return;

        if(transform.position.x <= _player.position.x)
        {
            transform.position = new Vector2(_player.position.x, 0);
        }
    }
}
