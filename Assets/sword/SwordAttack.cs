using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float attackRadius = 1.5f; // Радиус атаки
    public LayerMask enemyLayer; // Слой врагов
    public float damage = 10f; // Урон, который наносит меч

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Проверка нажатия ЛКМ
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        // Получаем позицию игрока
        Vector2 playerPosition = transform.position;

        // Проверяем, есть ли враги в радиусе атаки
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerPosition, attackRadius, enemyLayer);

        // Если враги были задеты
        if (hitEnemies.Length > 0)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                EnemyAI enemyScript = enemy.GetComponent<EnemyAI>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(damage); // Наносим урон врагу
                    Debug.Log("Атака задела врага: " + enemy.name); // Откладка в консоль
                }
            }
        }
        else
        {
            Debug.Log("Враги не были задеты.");
        }
    }

    // Для визуализации радиуса атаки в редакторе
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}