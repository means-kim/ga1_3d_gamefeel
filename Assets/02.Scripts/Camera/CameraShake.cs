using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _shakeDuration = 0.1f;
    [SerializeField] private float _shakePower = 0.1f;
    private bool _isShake = false;
    private float _currentShakeTimer = 0f;
    private Vector3 _originalPosition;

    private void Start()
    {
        _originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (!_isShake)
        {
            return;
        }

        UpdateScreenShake();
    }

    public void ScreenShake()
    {
        _isShake = true;
        _currentShakeTimer = 0f;
    }

    private void UpdateScreenShake()
    {
        _currentShakeTimer += Time.deltaTime;

        Vector3 randomOffset = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f) * _shakePower;
        transform.localPosition = _originalPosition + randomOffset;

        if (_currentShakeTimer >= _shakeDuration)
        {
            _isShake = false;
            transform.localPosition = _originalPosition;
            _currentShakeTimer = 0f;
        }
    }
}
