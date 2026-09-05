using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            Debug.Log("공격 감지");
            _animator.SetTrigger("Attack");
        }
    }
}
