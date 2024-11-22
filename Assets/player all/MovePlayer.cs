using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения игрока
    private bool isAlive = true; // Состояние игрока (жив/мертв)

    void Update()
    {
        if (isAlive)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        // Получаем ввод от клавиатуры
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D или стрелки влево/вправо
        float verticalInput = 0f;

        // Устанавливаем вертикальный ввод для "W" и "S"
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f; // Движение вверх
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f; // Движение вниз
        }

        // Создаем вектор движения
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void Die()
    {
        isAlive = false; // Игрок мертв
        Debug.Log("Player died!");
    }

    public void Revive()
    {
        isAlive = true; // Игрок снова жив
        Debug.Log("Player respawned!");
    }
}