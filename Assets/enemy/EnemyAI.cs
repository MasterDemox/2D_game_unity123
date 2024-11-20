using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // ������ �� ������
    public float detectionRange = 5f; // ������ ����������� ������
    public float attackRange = 1.5f; // ������, � ������� ���� ��������������� ��� �����
    public float moveSpeed = 2f; // �������� �������� �����
    public float attackDuration = 2f; // ����� ��������� �� "�����"
    public float damage = 20f; // ����, ������� ������� ����

    public float maxHealth = 100f; // ������������ �������� �����
    private float currentHealth; // ������� �������� �����

    public Transform spawnPoint; // ���������� ��� ������������

    private bool isAttacking = false; // ���� �����

    void Start()
    {
        currentHealth = maxHealth; // ������������� ������� �������� �� ��������
    }

    void Update()
    {
        if (isAttacking)
        {
            return; // ���� ���� �������, ������ �� ������
        }

        // ��������� ���������� �� ������
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            // ���� ���� � ������� �����������, ��������� � ������
            MoveTowardsPlayer(distanceToPlayer);
        }
    }

    private void MoveTowardsPlayer(float distanceToPlayer)
    {
        if (distanceToPlayer <= attackRange)
        {
            // ���� ���� � ������� �����, ��������������� � �������
            StartCoroutine(Attack());
        }
        else
        {
            // ��������� � ������
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;

        // ����� ������
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage); // ������� ���� ������
        }

        // ����� ����� �������� �������� ����� ��� ������ �������

        // ��������� �� ����� �����
        yield return new WaitForSeconds(attackDuration);

        // ���������� �����
        isAttacking = false;
    }

    // ����� ��� ��������� �����
    public void TakeDamage(float damage)
    {
        currentHealth -= damage; // ��������� �������� �� �������� �����
        Debug.Log($"Enemy took damage: {damage}. Current health: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die(); // ���� �������� ������ ��� ����� ����, �������� ����� ������
        }
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        // ������������ ����� �� ����������
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.position; // ������������� �����
            currentHealth = maxHealth; // ��������������� ��������
        }
        else
        {
            Destroy(gameObject); // ���������� ������ �����, ���� ���������� �� �����
        }
    }
}