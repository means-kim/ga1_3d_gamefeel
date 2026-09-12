using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        transform.position = _player.position + _offset;

    }
}
