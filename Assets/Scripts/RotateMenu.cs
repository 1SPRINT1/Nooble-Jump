using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMenu : MonoBehaviour
{
    public float speed = 10f; // Скорость шара
    public float bounceForce = 5f; // Сила отскока от Коллайдера

    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.up; // Начальное направление движения
    }

    void FixedUpdate()
    {
        rb.velocity = direction * speed; // Движение шара

        // Проверяем столкновение с Коллайдером
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("FakeZone"))
            {
                // Отскок от Коллайдера
                Vector2 normal = (transform.position - collider.transform.position).normalized;
                direction = Vector2.Reflect(direction, normal);
                rb.AddForce(normal * bounceForce, ForceMode2D.Impulse);

                // Рандомное направление движения
                direction = Quaternion.AngleAxis(Random.Range(-90f, 90f), Vector3.forward) * direction;
            }
        }
    } 
}
