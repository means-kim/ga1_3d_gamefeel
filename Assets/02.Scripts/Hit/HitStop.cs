using UnityEngine;

public class HitStop : MonoBehaviour
{
    [SerializeField] private float _hitStopDuration = 0.05f;
    private float _currentHitStopDuration = 0f;
    private bool _isHitStop = false;

    private void Update()
    {
        if (!_isHitStop)
        {
            return;
        }

        _currentHitStopDuration += Time.unscaledDeltaTime;

        if (_currentHitStopDuration >= _hitStopDuration)
        {
            Time.timeScale = 1f;
            _currentHitStopDuration = 0;
        }
    }

    public void ScreenStop()
    {
        _currentHitStopDuration = 0f;
        Time.timeScale = 0f;
        _isHitStop = true;

    }
}
