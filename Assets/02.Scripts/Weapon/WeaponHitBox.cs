using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private CameraShake _cameraShake;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(_damage);
            Debug.Log("충동직전");
            _playerAttack.StartRecovery();
            _cameraShake.ScreenShake();
        }
    }
}