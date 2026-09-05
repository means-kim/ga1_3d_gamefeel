using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _health = 100;
    private float _currentTime = 0f;
    [SerializeField] private float _hitStopTimer = 0.2f;
    [SerializeField] private float _knockBackPower = 1f;
    private bool _isHit = false;
    [SerializeField] private HitStop _hitstop;
    private void Start()
    {
        _player = GameObject.FindWithTag("Player");

        if (_player == null)
        {
            Debug.Log("플레이어를 찾지 못했습니다.");
        }
    }

    private void Update()
    {
        if (_player == null)
        {
            return;
        }

        HitStun();

        if (_isHit)
        {
            return;
        }

        Move();
    }

    private void Move()
    {
        Vector3 direction = _player.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log($"체력 : {_health}");

        _hitstop.ScreenStop();

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            _isHit = true;
        }
    }

    private void HitStun()
    {
        if (_isHit)
        {
            _currentTime += Time.unscaledDeltaTime;
            KnockBack();
            if (_currentTime >= _hitStopTimer)
            {
                _isHit = false;
                _currentTime = 0f;
                return;
            }
        }
    }

    private void KnockBack()
    {
        Vector3 direction = transform.position - _player.transform.position;
        direction.Normalize();
        transform.Translate(direction * _knockBackPower * Time.deltaTime);
    }
}