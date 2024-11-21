using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public float attackRadius = 1.5f; // ������ �����
    public LayerMask enemyLayer; // ���� ������
    public float damage = 10f; // ����, ������� ������� ���

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // �������� ������� ���
        {
            PerformAttack();
        }
    }

    void PerformAttack()
    {
        // �������� ������� ������
        Vector2 playerPosition = transform.position;

        // ���������, ���� �� ����� � ������� �����
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerPosition, attackRadius, enemyLayer);

        // ���� ����� ���� ������
        if (hitEnemies.Length > 0)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                EnemyAI enemyScript = enemy.GetComponent<EnemyAI>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(damage); // ������� ���� �����
                    Debug.Log("����� ������ �����: " + enemy.name); // �������� � �������
                }
            }
        }
        else
        {
            Debug.Log("����� �� ���� ������.");
        }
    }

    // ��� ������������ ������� ����� � ���������
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}