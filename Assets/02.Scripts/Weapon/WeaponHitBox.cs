using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private PlayerAttack _playerAttack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(_damage);
            Debug.Log("충동직전");
            _playerAttack.StartRecovery();
        }
    }
}