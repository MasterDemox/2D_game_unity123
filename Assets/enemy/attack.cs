using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; // Скорость врага
    public float attackRange = 1f; // Дистанция атаки
    public float attackDamage = 10f; // Урон атаки
    public float attackCooldown = 1f; // Время между атаками

    private Transform Player; // Ссылка на игрока
    private float lastAttackTime;

    void Start()
    {
        // Находим игрока по тегу
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Player != null)
        {
            MoveTowardsPlayer();

            // Проверяем, можем ли атаковать
            if (Vector2.Distance(transform.position, Player.position) <= attackRange)
            {
                AttackPlayer();
            } 
        }
    }

    void MoveTowardsPlayer()
    {
        // Двигаем врага к игроку
        Vector2 direction = (Player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
    }

    void AttackPlayer()
    {
        // Проверяем, прошло ли время для атаки
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            // Логика атаки
            Debug.Log("Attack!");
            lastAttackTime = Time.time;

            // Наносим урон игроку
            Player playerScript = Player.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(attackDamage);
            }
        }
    }
}