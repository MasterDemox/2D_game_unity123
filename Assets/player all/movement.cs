using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f; // Увеличьте скорость для более заметного эффекта
    private Vector2 moveVector;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveVector = Vector2.zero; // Сбрасываем вектор движения

        if (Input.GetKey(KeyCode.W)) // Вверх
        {
            moveVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S)) // Вниз
        {
            moveVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) // Влево
        {
            moveVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D)) // Вправо
        {
            moveVector.x = 1;
        }

        // Нормализуем вектор движения, чтобы избежать ускорения при диагональном движении
        if (moveVector != Vector2.zero)
        {
            moveVector.Normalize();
        }

        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
    }
}
