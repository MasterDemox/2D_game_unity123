using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Ссылка на игрока
    public float detectionRange = 5f; // Радиус обнаружения игрока
    public float attackRange = 1.5f; // Радиус, в котором враг останавливается для атаки
    public float moveSpeed = 2f; // Скорость движения врага
    public float attackDuration = 2f; // Время остановки на "атаку"
    public float damage = 20f; // Урон, который наносит враг

    public float maxHealth = 100f; // Максимальное здоровье врага
    private float currentHealth; // Текущее здоровье врага

    public Transform spawnPoint; // Спавнпоинт для телепортации

    private bool isAttacking = false; // Флаг атаки

    void Start()
    {
        currentHealth = maxHealth; // Устанавливаем текущее здоровье на максимум
    }

    void Update()
    {
        if (isAttacking)
        {
            return; // Если враг атакует, ничего не делаем
        }

        // Проверяем расстояние до игрока
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // Если враг в радиусе обнаружения, двигаемся к игроку
            MoveTowardsPlayer(distanceToPlayer);
        }
    }

    private void MoveTowardsPlayer(float distanceToPlayer)
    {
        if (distanceToPlayer <= attackRange)
        {
            // Если враг в радиусе атаки, останавливаемся и атакуем
            StartCoroutine(Attack());
        }
        else
        {
            // Двигаемся к игроку
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;

        // Атака игрока
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage); // Наносим урон игроку
        }

        // Здесь можно добавить анимацию атаки или другие эффекты

        // Остановка на время атаки
        yield return new WaitForSeconds(attackDuration);

        // Завершение атаки
        isAttacking = false;
    }

    // Метод для получения урона
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // Уменьшаем здоровье на величину урона
        Debug.Log($"Enemy took damage: {damage}. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die(); // Если здоровье меньше или равно нулю, вызываем метод смерти
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        // Телепортация врага на спавнпоинт
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position; // Телепортируем врага
            currentHealth = maxHealth; // Восстанавливаем здоровье
        }
        else
        {
            Destroy(gameObject); // Уничтожаем объект врага, если спавнпоинт не задан
        }
    }
}