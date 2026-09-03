using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject _player;
    [SerializeField] private float _moveSpeed;
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
        Vector3 direction = _player.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * _moveSpeed * Time.deltaTime);
    }
}