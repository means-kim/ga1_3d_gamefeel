using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _mouseSensitivity = 5f;

    private float _valueY;

    private void LateUpdate()
    {
        PlayerFollow();
        RotateCamera();
    }

    private void PlayerFollow()
    {
        transform.position = _player.position + _offset;
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        _valueY += mouseX * _mouseSensitivity;

        transform.rotation = Quaternion.Euler(0f, _valueY, 0f);
    }
}
