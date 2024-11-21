using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3.0f; // �������� �������� �����
    public int damage = 10; // ����, ������� ���� �������
    public float attackRange = 1.5f; // ��������� �����
    public float attackCooldown = 1.0f; // ����� ����� �������

    private float lastAttackTime = 0f; // ����� ��������� �����
    private Transform player; // ������ �� ������

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ����� ������ �� ����
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);
            if (distance <= attackRange)
            {
                // ���� ���� � �������� ��������� �����, ������� ������
                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    AttackPlayer();
                }
            }
            else
            {
                // ���� ���� �� � �������� ��������� �����, �������� � ������
                MoveTowardsPlayer();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        // �������� ����� � ������
        Vector3 direction = (player.position - transform.position).normalized; // ����������� � ������
        transform.position += direction * moveSpeed * Time.deltaTime; // ����������� �����
    }

    void AttackPlayer()
    {
        lastAttackTime = Time.time; // ��������� ����� ��������� �����
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>(); // �������� ��������� PlayerHealth
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage); // ������� ���� ������
        }
    }
}