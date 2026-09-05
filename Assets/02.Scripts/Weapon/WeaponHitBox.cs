using UnityEngine;

public class WeaponHitBox : MonoBehaviour
{
    private PlayerAttack _playerAttack;
    [SerializeField] private int _damage;

    public WeaponHitBox(PlayerAttack playerAttack)
    {
        _playerAttack = playerAttack;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(_damage);
        }
    }
}