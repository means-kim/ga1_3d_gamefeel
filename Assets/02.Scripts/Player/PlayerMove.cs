using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    [SerializeField] private Animator _animator;


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0f, v).normalized;
        bool isRunning = direction.magnitude > 0.1f;
        _animator.SetBool("IsRunning", isRunning);
        // Debug.Log($"isRunning : {isRunning}");

        Vector3 normalizedSpeed = (direction * Speed).normalized;

        transform.Translate(normalizedSpeed * Speed * Time.deltaTime);
    }
}