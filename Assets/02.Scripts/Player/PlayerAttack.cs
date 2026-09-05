using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _recoveryDuration = 0.3f;
    private bool _isRecovery;
    private float _currentRecoveryTime;
    private bool _isAttacking;

    private void Update()
    {
        if (_isRecovery)
        {
            UpdateRecovery();
            return;
        }

        if (_isAttacking)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("공격 감지");
            _animator.SetTrigger("Attack");
            _isAttacking = true;
        }
    }

    public void StartRecovery()
    {
        _isRecovery = true;
        _currentRecoveryTime = 0f;
        Debug.Log("역경직 시작");
    }

    private void UpdateRecovery()
    {
        if (!_isRecovery)
        {

            return;
        }

        _currentRecoveryTime += Time.deltaTime;
        if (_currentRecoveryTime >= _recoveryDuration)
        {
            _isRecovery = false;
            _currentRecoveryTime = 0f;
            Debug.Log("역경직 끝");
        }
    }

    public void EndAttack()
    {
        _isAttacking = false;
    }
}
