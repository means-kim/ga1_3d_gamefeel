using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;
    [SerializeField] private Animator _animator;
    private Ray _ray;


    private void Update()
    {
        Move();
        LookAtMouse();
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

        // transform.Translate(normalizedSpeed * Speed * Time.deltaTime);
        transform.position += normalizedSpeed * Speed * Time.deltaTime;
    }

    private void LookAtMouse()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(_ray, out hit))
        {
            Vector3 direction = hit.point - transform.position;
            direction.y = 0f;

            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}