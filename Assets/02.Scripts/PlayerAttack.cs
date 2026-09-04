using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger("Attack");
        }
    }
}
