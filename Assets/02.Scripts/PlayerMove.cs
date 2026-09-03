using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed;


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0f, v).normalized;

        Vector3 normalizedSpeed = (direction * Speed).normalized;

        transform.Translate(normalizedSpeed * Speed * Time.deltaTime);
    }
}