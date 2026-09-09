using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private CameraShake _cameraShake;
    [SerializeField] private GameObject _hitEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            SpwanHitEffect();
            enemy.TakeDamage(_damage);
            Debug.Log("충동직전");
            _playerAttack.StartRecovery();
            _cameraShake.ScreenShake();
        }
    }

    private void SpwanHitEffect()
    {
        Instantiate(_hitEffect, transform.position, Quaternion.identity);
    }
}