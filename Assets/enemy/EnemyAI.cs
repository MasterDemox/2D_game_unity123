using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5f;
    public float attackRange = 1.5f;
    public float moveSpeed = 2f;
    public float attackDuration = 2f;
    public float damage = 20f;
    public float maxHealth = 100f;
    private float currentHealth;
    public Transform spawnPoint;

    private bool isAttacking = false;
    private EnemyKillTracker killTracker;

    private Animator animator;

    // Храните текущее направление (флип) врага
    private bool isFacingRight = true;

    void Start()
    {
        currentHealth = maxHealth;
        killTracker = Object.FindFirstObjectByType<EnemyKillTracker>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isAttacking)
        {
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            MoveTowardsPlayer(distanceToPlayer);
        }
    }

    private void MoveTowardsPlayer(float distanceToPlayer)
    {
        if (distanceToPlayer <= attackRange)
        {
            StartCoroutine(Attack());
        }
        else
        {
            animator.SetBool("isRunning", true);
            Vector3 direction = (player.position - transform.position).normalized;

            // Флип по оси X в зависимости от направления движения
            if (direction.x > 0 && !isFacingRight)
            {
                Flip(); // Поворачиваем врага вправо
            }
            else if (direction.x < 0 && isFacingRight)
            {
                Flip(); // Поворачиваем врага влево
            }

            // Двигаем врага к игроку
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight; // Меняем направление
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Инвертируем масштаб по оси X
        transform.localScale = localScale; // Применяем новый масштаб
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetTrigger("Attacking");

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }

        yield return new WaitForSeconds(attackDuration);
        isAttacking = false;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log($"Enemy took damage: {damage}. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");

        if (killTracker != null)
        {
            killTracker.IncrementKillCount();
        }

        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position;
            currentHealth = maxHealth;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}