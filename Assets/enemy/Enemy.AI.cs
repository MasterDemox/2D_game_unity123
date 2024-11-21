using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3.0f; // Скорость движения врага
    public int damage = 10; // Урон, который враг наносит
    public float attackRange = 1.5f; // Дальность атаки
    public float attackCooldown = 1.0f; // Время между атаками

    private float lastAttackTime = 0f; // Время последней атаки
    private Transform player; // Ссылка на игрока

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Найти игрока по тегу
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= attackRange)
            {
                // Если враг в пределах дистанции атаки, атакуем игрока
                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    AttackPlayer();
                }
            }
            else
            {
                // Если враг не в пределах дистанции атаки, движемся к игроку
                MoveTowardsPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        // Движение врага к игроку
        Vector3 direction = (player.position - transform.position).normalized; // Направление к игроку
        transform.position += direction * moveSpeed * Time.deltaTime; // Перемещение врага
    }

    void AttackPlayer()
    {
        lastAttackTime = Time.time; // Обновляем время последней атаки
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>(); // Получаем компонент PlayerHealth
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage); // Наносим урон игроку
        }
    }
}